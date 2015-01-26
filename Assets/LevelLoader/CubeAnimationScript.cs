using UnityEngine;
using System.Collections;

public class CubeAnimationScript : MonoBehaviour {

	Transform tr;
	// Use this for initialization
	void Start () {
		tr = transform;
	}
	
	// Update is called once per frame
	void Update () {
		//Animazione per il cubo momentaneo del loader
		tr.Rotate(0.0F, -90.0F*Time.deltaTime, 0.0F); 
	}
}
