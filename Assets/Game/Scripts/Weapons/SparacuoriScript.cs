using UnityEngine;
using System.Collections;

public class SparacuoriScript : WeaponScript {
	
	public override void Fire()
	{
		if (this.bulletCount > 0) {
			GameObject bullet = GameObject.Instantiate (this.bulletPrefab, bulletStart.position, this.transform.rotation) as GameObject;
			bullet.GetComponent<BulletScript>().ownerId = _playerId;
			this.bulletCount--;
			GetComponents<AudioSource>()[0].Play();
		}
	}
}
