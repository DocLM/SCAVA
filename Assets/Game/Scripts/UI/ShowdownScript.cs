using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowdownScript : MonoBehaviour {

	public Image player1;
	public Image player2;
	public bool alreadydo = false;
	public bool showdown = false;
	bool godown = false;
	// Use this for initialization
	void Start () {
		string resourcePath = string.Empty;
		resourcePath = "Textures/" + SelectedCharacter.firstPlayer + "/ShowdownLeft";
		this.player1.sprite = (Sprite)Resources.Load (resourcePath, typeof(Sprite));
		resourcePath = "Textures/" + SelectedCharacter.secondPlayer + "/ShowdownRight";
		this.player2.sprite = (Sprite)Resources.Load (resourcePath, typeof(Sprite));
		this.gameObject.GetComponent<Canvas> ().planeDistance = 0;
	}
	
	// Update is called once per frame
	void Update () {
	if (this.showdown) {
						if (godown)
								this.gameObject.GetComponent<Canvas> ().planeDistance -= 0.01F;
						else
								this.gameObject.GetComponent<Canvas> ().planeDistance += 0.01F;

						if (this.gameObject.GetComponent<Canvas> ().planeDistance >= 1) {
								StartCoroutine (slow ());
								this.godown = true;

						}
						if (this.gameObject.GetComponent<Canvas> ().planeDistance <= 0)
						{
								this.godown = false;
								this.showdown = false;
								Time.timeScale=1;
						}
				}

	}
	IEnumerator slow()
	{
		yield return new WaitForSeconds (3);
	}
}
