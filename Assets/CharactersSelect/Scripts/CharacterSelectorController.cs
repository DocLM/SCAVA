using UnityEngine;
using System.Collections;

public class CharacterSelectorController : MonoBehaviour {

	// Use this for initialization
	public FirstSelectedPlayer primo;
	public SecondSelectedPlayer second;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update (){
		if (this.primo.OK && this.second.OK)
						loadGame ();
	}

	private void loadGame()
	{
		LoadLevel.scene ="Game";
		Application.LoadLevel("LevelLoader");
	}
}
