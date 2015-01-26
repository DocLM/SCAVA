using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResetScript : MonoBehaviour {

	public Image i;
	float countDown = 5f;
	
	
	// Use this for initialization
	void Start () {
		if(SelectedCharacter.win == 1)
			i.sprite =  (Sprite)Resources.Load("Textures/Backgrounds/End/Player1", typeof(Sprite));
		else if(SelectedCharacter.win == 2)
			i.sprite =  (Sprite)Resources.Load("Textures/Backgrounds/End/Player2", typeof(Sprite));
		Time.timeScale = 1;

		

	}
	
	// Update is called once per frame
	void Update () {
	
		countDown -= Time.deltaTime;
		Debug.Log (countDown.ToString());
		if(countDown <= 0)
			Application.LoadLevel("Menu");
	}
	
	

	
}
