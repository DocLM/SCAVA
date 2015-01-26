using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FirstSelectedPlayer : MonoBehaviour {
	private int _count = 0;
	private string[] characters;
	private Image image;
	public bool OK = false;
	private bool updateImage = false;
	public Image child;
	void Start () {
		characters = PlayerCharacters.characters.Split(new char[] {','});
		SelectedCharacter.firstPlayer = characters [0];
		this.image = this.GetComponent<Image> ();
		this.updateImage = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButton (PlayersCommands.FirstPlayerControllerFire) || Input.GetKey (PlayersCommands.FirstPlayerKeyboardFire))
		{
			this.OK = true;
			return;
		}
		
		
			if (Input.GetKeyDown (PlayersCommands.FirstPlayerKeyboardLeft) || Input.GetAxisRaw (PlayersCommands.FirstPlayerControllerWeaponHorizontalAxis) < -0.9) {
				if (--_count < 0)
					this._count = 0;
				
			} else if (Input.GetKeyDown (PlayersCommands.FirstPlayerKeyboardRight) || Input.GetAxisRaw (PlayersCommands.FirstPlayerControllerWeaponHorizontalAxis) > 0.9) {
				if (++_count >  this.characters.Length - 1 )
					this._count = 0;
				
				
			}
			Debug.Log("Request resource: " + "Textures/"+ SelectedCharacter.firstPlayer + "/Face");
			Object resource = Resources.Load("Textures/"+ SelectedCharacter.firstPlayer + "/Face", typeof(Sprite));
			Image name = this.image.GetComponentInChildren<Image>();
			this.image.sprite = (Sprite)resource;
			resource = Resources.Load("Textures/"+ SelectedCharacter.firstPlayer + "/Name", typeof(Sprite));
			child.sprite = (Sprite)resource;			
			SelectedCharacter.firstPlayer = characters [this._count];
			
		
	}	
}
