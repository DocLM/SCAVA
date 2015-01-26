using UnityEngine;
using System.Collections;

public class LoadLevelCameraScript : MonoBehaviour {

	AsyncOperation async;

	// Update is called once per frame
	void Update () {
		SwitchScene ();
	}

	private void Start()
	{
		StartCoroutine(LoadScene());
	}
	
	IEnumerator LoadScene()
	{
		//Se la scena è vuot non carico
		if (LoadLevel.scene == "")
			yield break;

		//Comincio a caricare la scena e disattivo la visualizzazione
		async = Application.LoadLevelAsync(LoadLevel.scene);
		async.allowSceneActivation = false;
		
		Debug.Log("start loading");
		
		yield return async;
	}
	
	private void SwitchScene()
	{
		Debug.Log("switching");
		//Cambio scena
		if (async != null)
			async.allowSceneActivation = true;
	}
}
