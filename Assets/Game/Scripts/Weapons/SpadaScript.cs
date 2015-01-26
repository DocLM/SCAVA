using UnityEngine;
using System.Collections;

public class SpadaScript : WeaponScript {

	private bool countStarted = false;
	public int damage = 2;

				
										
	// Update is called once per frame
	void Update () {
		float vertical = Input.GetAxisRaw(verticalMov);
		float horizontal = Input.GetAxisRaw(horizontalMov);
		WeaponRotate(vertical, horizontal);	

			

	}
	
	public override void Fire()
	{
	}
	
	

	
	void OnTriggerEnter2D(Collider2D other)
	{		
		if(other.tag == "Player")
		{
			CharacterScript cs = other.GetComponent<CharacterScript>();
			if(cs.playerId != ch.playerId)
			{			
				cs.getHit(damage);
				ch.canDig = true;
				ch.haveGun = false;
				Destroy(gameObject);
			}
		}
		
	}
}
