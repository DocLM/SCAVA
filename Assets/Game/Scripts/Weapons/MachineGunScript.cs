using UnityEngine;
using System.Collections;

public class MachineGunScript : GunScript {
	
	public override void Fire()
	{
		if (this.bulletCount > 0) 
		{
			GameObject bullet1 = GameObject.Instantiate (bulletPrefab) as GameObject;
			GameObject bullet2 = GameObject.Instantiate (bulletPrefab) as GameObject;
			GameObject bullet3 = GameObject.Instantiate (bulletPrefab) as GameObject;
			bullet1.GetComponent<BulletScript>().ownerId = _playerId;
			bullet2.GetComponent<BulletScript>().ownerId = _playerId;
			bullet3.GetComponent<BulletScript>().ownerId = _playerId;
			bullet1.transform.position = bulletStart.position;
			bullet2.transform.position = bulletStart.position;
			bullet3.transform.position = bulletStart.position;
			bullet1.transform.rotation = transform.rotation;
			bullet2.transform.rotation = transform.rotation;
			bullet3.transform.rotation = transform.rotation;
			bullet1.transform.Rotate(new Vector3(0,0, -33f));			
			bullet3.transform.Rotate(new Vector3(0,0, +33f));
			
			
			this.bulletCount--;
			GetComponents<AudioSource>()[0].Play();
		}
	}
	

}
