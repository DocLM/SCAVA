using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public float speed = 1;
	public int damage = 1;
	public int ownerId;
	public GameObject hitEffect;
	
	// Use this for initialization
	void Start () {
		StartCoroutine("Kill");
		rigidbody2D.AddForce(transform.up * speed);
	}
	
	// Update is called once per frame
	void Update () {
		//this.transform.position += this.transform.up * this.speed * Time.deltaTime;

	}
	
	IEnumerator Kill()
	{
		yield return new WaitForSeconds(5f);
		Destroy(gameObject);
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log ("Hit " + other.name + " " + other.tag);
		if(other.tag == "arena")
			return;
		if(other.tag == "Player")
		{
			CharacterScript cs = other.GetComponent<CharacterScript>();
			if(cs.playerId == ownerId)
			{
				Debug.Log ("No friendly fire here");
				return;
			}
			Debug.Log(ownerId);
			cs.getHit(damage);
		}
		if(other.gameObject.name == gameObject.name)
		{
			if(other.gameObject.GetComponent<BulletScript>().ownerId == ownerId)
			{
				return;
			}
		}
		GameObject hit = (GameObject) Instantiate(hitEffect);
		hit.transform.position = transform.position;
		Debug.Log("projectile destroyed by " + other.gameObject.name);
		Destroy(gameObject);
		
		
	}
		
}
