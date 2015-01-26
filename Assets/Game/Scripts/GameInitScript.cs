using UnityEngine;
using System.Collections;

public class GameInitScript : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;
	// Use this for initialization
	void Start () {
		string resourcePath = "Animation/" + SelectedCharacter.firstPlayer + "/" + SelectedCharacter.firstPlayer + "AnimatorController";
		Debug.Log ("Load resource: " + resourcePath);
		RuntimeAnimatorController Player1Animation = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load(resourcePath, typeof(RuntimeAnimatorController)));
		player1.GetComponent<Animator>().runtimeAnimatorController = Player1Animation;
		resourcePath = "Textures/" + SelectedCharacter.firstPlayer + "/spritesheet" + SelectedCharacter.firstPlayer;
		Debug.Log ("Load resource: " + resourcePath);
		Sprite Player1Sprite = (Sprite)Resources.Load(resourcePath, typeof(Sprite));
		player1.GetComponent<SpriteRenderer>().sprite = Player1Sprite;
		player1.GetComponent<Animator> ().SetInteger ("WalkState", 1);

		resourcePath = "Animation/" + SelectedCharacter.secondPlayer + "/" + SelectedCharacter.secondPlayer + "AnimatorController";
		Debug.Log ("Load resource: " + resourcePath);
		RuntimeAnimatorController Player2Animation = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load(resourcePath, typeof(RuntimeAnimatorController)));
		player2.GetComponent<Animator>().runtimeAnimatorController = Player2Animation;
		resourcePath = "Textures/" + SelectedCharacter.secondPlayer + "/spritesheet" + SelectedCharacter.secondPlayer;
		Debug.Log ("Load resource: " + resourcePath);
		Sprite Player2Sprite = (Sprite)Resources.Load(resourcePath, typeof(Sprite));
		player2.GetComponent<SpriteRenderer>().sprite = Player2Sprite;
		player2.GetComponent<Animator> ().SetInteger ("WalkState", -1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
