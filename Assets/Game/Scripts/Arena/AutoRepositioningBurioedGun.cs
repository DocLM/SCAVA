using UnityEngine;
using System.Collections;

public class AutoRepositioningBurioedGun : MonoBehaviour {

	public Arena arena;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerStay2D(Collider2D other)
	{	Debug.Log("Buried gun colliding wiht " + other.name);
		if(other.tag == "obstacle")
		{
			arena.generateGunSpawn();
		}
	}
}
