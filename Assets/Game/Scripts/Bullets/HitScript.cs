using UnityEngine;
using System.Collections;

public class HitScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine("Kill");
	}
	
	IEnumerator Kill()
	{
		yield return new WaitForSeconds(0.2f);
		Destroy(gameObject);
	}
	
}
