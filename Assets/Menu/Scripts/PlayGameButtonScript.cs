using UnityEngine;
using System.Collections;

public class PlayGameButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnMouseUp()
	{
		//Carico il loader asincrono per caricare la schermata di caricamento.
		Debug.Log ("Play Game button clicked...");
		LoadLevel.scene = "CharactersSelect";
		Application.LoadLevel("LevelLoader");
	}
}
