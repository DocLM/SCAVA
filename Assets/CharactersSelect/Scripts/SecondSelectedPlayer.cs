using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SecondSelectedPlayer : MonoBehaviour {

	private int _count;
	private string[] characters;
	private Image image;
	public bool OK = false;
	private bool updateImage = false;
	public Image child;
	void Start () {
		characters = PlayerCharacters.characters.Split(new char[] {','});
		SelectedCharacter.secondPlayer = characters [0];
		this.image = this.GetComponent<Image> ();
		this.updateImage = true;

	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetButton (PlayersCommands.SecondPlayerControllerFire) || Input.GetKey (PlayersCommands.SecondPlayerKeyboardFire))
		{
			this.OK = true;
			return;
		}
		
		
		if (Input.GetKeyDown (PlayersCommands.SecondPlayerKeyboardLeft) || Input.GetAxisRaw (PlayersCommands.SecondPlayerControllerWeaponHorizontalAxis) < -0.9) {
			if (--_count < 0)
				this._count = 0;
			
		} else if (Input.GetKeyDown (PlayersCommands.SecondPlayerKeyboardRight) || Input.GetAxisRaw (PlayersCommands.SecondPlayerControllerWeaponHorizontalAxis) > 0.9) {
			if (++_count >  this.characters.Length - 1 )
				this._count = 0;
			
			
		}
		Debug.Log("Request resource: " + "Textures/"+ SelectedCharacter.secondPlayer + "/Face");
		Object resource = Resources.Load("Textures/"+ SelectedCharacter.secondPlayer + "/Face", typeof(Sprite));
		Image name = this.image.GetComponentInChildren<Image>();
		this.image.sprite = (Sprite)resource;
		resource = Resources.Load("Textures/"+ SelectedCharacter.secondPlayer + "/Name", typeof(Sprite));
		child.sprite = (Sprite)resource;			
		SelectedCharacter.secondPlayer = characters [this._count];

	}
	
}
