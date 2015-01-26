using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class PlayerScoreScript : MonoBehaviour {
	
	public int PlayerScore;
	public string Orientation;
	public CharacterScript player;
	// Use this for initialization
	Text element;

	void Start () {
		this.element = GetComponent<Text> ();
		//this.element.text = "Player " + this.player.playerId + ": " + this.PlayerScore;
	}
	
	// Update is called once per frame
	void Update () {
		//this.element.text = "Player " + this.player.playerId + ": " + this.PlayerScore;
	}
}
