using UnityEngine;
using System.Collections;

public class AboutButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnMouseUp()
	{
		//Carico i titoli di coda
		Debug.Log ("About button clicked...");
		Application.LoadLevel("Credits");
	}
}
