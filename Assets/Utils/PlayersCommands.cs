using UnityEngine;
using System.Collections;

//Classe per mappare tutti i comandi per i players e utilizzare un unico riferimento.
public static class PlayersCommands {
	public static KeyCode FirstPlayerKeyboardUp = KeyCode.W;
	public static KeyCode FirstPlayerKeyboardDown = KeyCode.S;
	public static KeyCode FirstPlayerKeyboardLeft = KeyCode.A;
	public static KeyCode FirstPlayerKeyboardRight = KeyCode.D;
	public static KeyCode FirstPlayerKeyboardFire = KeyCode.E;
	public static string FirstPlayerControllerVerticalAxis = "Vertical1";
	public static string FirstPlayerControllerHorizontalAxis = "Horizontal1";
	public static string FirstPlayerControllerWeaponVerticalAxis = "WeaponVertical1";
	public static string FirstPlayerControllerWeaponHorizontalAxis = "WeaponHorizontal1";
	public static string FirstPlayerControllerFire = "Fire1";

	public static KeyCode SecondPlayerKeyboardUp = KeyCode.UpArrow;
	public static KeyCode SecondPlayerKeyboardDown = KeyCode.DownArrow;
	public static KeyCode SecondPlayerKeyboardLeft = KeyCode.LeftArrow;
	public static KeyCode SecondPlayerKeyboardRight = KeyCode.RightArrow;
	public static KeyCode SecondPlayerKeyboardFire = KeyCode.K;
	public static string SecondPlayerControllerVerticalAxis = "Vertical2";
	public static string SecondPlayerControllerHorizontalAxis = "Horizontal2";
	public static string SecondPlayerControllerWeaponVerticalAxis = "WeaponVertical2";
	public static string SecondPlayerControllerWeaponHorizontalAxis = "WeaponHorizontal2";
	public static string SecondPlayerControllerFire = "Fire2";
}
