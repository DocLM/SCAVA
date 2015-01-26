using UnityEngine;
using System.Collections;

public class HelpArrowScript : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		StartCoroutine("Kill");
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	
	}
	
	IEnumerator Kill()
	{
		yield return new WaitForSeconds(0.5f);
		Destroy(gameObject);
	}
}
