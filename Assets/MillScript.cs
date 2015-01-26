using UnityEngine;
using System.Collections;

public class MillScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 actualRotation = transform.rotation.eulerAngles;
		float addRotation = transform.eulerAngles.z + 0.001f;
		transform.Rotate (0, 0, 0.1f);
	}
}
