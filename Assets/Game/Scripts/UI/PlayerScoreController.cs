using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerScoreController : MonoBehaviour {
	
	public PlayerScoreScript FirstPlayerLabel;
	public PlayerScoreScript SecondPlayerLabel;
	
	public GameObject heartPrefab;
	public List<GameObject> PlayerOneHeart;
	public List<GameObject> PlayerTwoHeart;
	
	private bool endGame = false;
	
	// Use this for initialization
	void Start () {
		this.PlayerOneHeart = new List<GameObject> ();
		this.PlayerTwoHeart = new List<GameObject> ();
		this.loadHearts (this.FirstPlayerLabel.player.health, this.FirstPlayerLabel, this.PlayerOneHeart, true);
		this.loadHearts (this.SecondPlayerLabel.player.health, this.SecondPlayerLabel, this.PlayerTwoHeart);
		
	}
	
	// Update is called once per frame
	void Update () {
		if(endGame)
		{
			Time.timeScale=0;
			if(this.FirstPlayerLabel.player.health == 0)
				SelectedCharacter.win = 2;
			else
				SelectedCharacter.win = 1;
			LoadLevel.scene = "End";
			Application.LoadLevel("LevelLoader");
		}
		
		if (this.PlayerOneHeart.Count  > this.FirstPlayerLabel.player.health) {
			this.removeHearts(this.PlayerOneHeart.Count - this.FirstPlayerLabel.player.health, this.PlayerOneHeart);
		}
		
		if (this.PlayerTwoHeart.Count > this.SecondPlayerLabel.player.health) {
			this.removeHearts(this.PlayerTwoHeart.Count - this.SecondPlayerLabel.player.health, this.PlayerTwoHeart);
		}
		if (this.PlayerOneHeart.Count  < this.FirstPlayerLabel.player.health) {
			loadHearts (this.FirstPlayerLabel.player.health, this.FirstPlayerLabel, this.PlayerOneHeart, true);
		}
		
		if (this.PlayerTwoHeart.Count < this.SecondPlayerLabel.player.health) {
			this.loadHearts (this.SecondPlayerLabel.player.health, this.SecondPlayerLabel, this.PlayerTwoHeart);
		}
		
		
		if (this.FirstPlayerLabel.player.health <= 0 || this.SecondPlayerLabel.player.health <= 0) {
			endGame = true;
		}
		
	}
	
	
	
	private void loadHearts(int howmany, PlayerScoreScript who, List<GameObject> to, bool left = false)
	{
		float x, y, z;
		GameObject myinstant;
		int lenght = to.Count;
		int tot = lenght > 0 ? lenght + howmany + 1 : lenght + howmany;
		for(int i = lenght; i < tot; i++)
		{
			myinstant = (GameObject)GameObject.Instantiate(this.heartPrefab);
			myinstant.transform.parent = this.transform;
			if(left)
				x = who.transform.position.x - (this.transform.position.x) - 1.5F * i; //Non si fa ma non trovo la lunghezza
			else
				x = who.transform.position.x + (this.transform.position.x) + 1.5F * i; //Non si fa ma non trovo la lunghezza
			y = who.transform.position.y;
			z = who.transform.position.z;
			myinstant.transform.position = new Vector3(x, y, z);
			to.Add(myinstant);
			myinstant = null;
		}
	}
	
	private void removeHearts(int howmany, List<GameObject> to)
	{
		int length = to.Count-1;
		for (int i = length; i > length - howmany; i--) {
			GameObject.Destroy(to[i]);
			to.RemoveAt(i);
		}
	}
}
