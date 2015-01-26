using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Arena : MonoBehaviour {

	public float spaceLimitHorizontal = 7.5f;
	public float spaceLimitUp = 1.25f;
	public float spaceLimitDown = 4.5f;
	public float digDistance = 0.2f;
	public GameObject buriedGun; 
	public Vector3 weaponPoint;
	public GameObject[] weapons;
	private List<GameObject> holes;
	public GameObject holePrefab;	
	public GameObject helpArrowPrefab;


	// Use this for initialization
	void Start () {
		generateGunSpawn ();
		holes = new List<GameObject>();		
	}
	
	// Update is called once per frame
	void Update () {

	}


	public Vector3 generateGunSpawn(){
		weaponPoint = new Vector3(Random.Range(-(spaceLimitHorizontal-0.5f),+spaceLimitHorizontal -0.5f), Random.Range(-(spaceLimitDown -0.5f), spaceLimitUp -0.5f), 1);
		buriedGun.transform.position = weaponPoint;
		Debug.Log ("GunSpawn:" + weaponPoint);
		return weaponPoint;
	}

	public bool gunFound(Vector2 digPoint){
		float distance = Vector2.Distance (digPoint, new Vector2 (weaponPoint.x, weaponPoint.y));
		if ( distance <= digDistance) {
			Debug.Log ("Gun found!");
			foreach(GameObject hole in holes)
			{				
				Destroy(hole);
			}
			holes = new List<GameObject>();
			return true;
		} 
		else{
			Debug.Log("Dig again, you are still " + distance + " pixels far away ");
			GameObject newHole = GameObject.Instantiate(holePrefab) as GameObject;
			newHole.transform.SetParent(transform);
			newHole.transform.position = new Vector3(digPoint.x, digPoint.y -0.9f, 0);
			holes.Add(newHole);
			//create help arrow and make it point to gun
			GameObject help = (GameObject) GameObject.Instantiate(helpArrowPrefab);
			help.transform.position =  new Vector3(digPoint.x, digPoint.y -0.9f, -2);
			Vector3 direction = -help.transform.position + buriedGun.transform.position;			
			direction.Normalize();
			Debug.DrawRay( help.transform.position, direction, Color.red, 1);
			float rot_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
			help.transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
			help.transform.SetParent(transform);
			return false;
		}
	}
	
	public GameObject GetRandomWeapon()
	{
		int index = Random.Range(0, weapons.Length);
		return GameObject.Instantiate(weapons[index]) as GameObject;
	}

}
