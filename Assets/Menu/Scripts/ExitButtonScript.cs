using UnityEngine;
using System.Collections;

public class ExitButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnMouseUp()
	{
		//Esco dall'applicazione
		Debug.Log ("Closing application...");
		Application.Quit ();
	}
}
