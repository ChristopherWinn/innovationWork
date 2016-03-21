using UnityEngine;
using System.Collections;

public class lightController : MonoBehaviour {

	private GameObject mainLight;
	private Light mainLightLight;

	private GameObject gameManager;
	private gameManager gameManagerScript;

	// Use this for initialization
	void Start () 
	{
		gameManager = GameObject.Find ("gameManager");
		gameManagerScript = gameManager.GetComponent <gameManager> ();

		mainLight = GameObject.Find ("Spotlight");
		mainLightLight = mainLight.GetComponent <Light> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (gameManagerScript.numberOfFriends > 0) {
			mainLightLight.intensity = gameManagerScript.numberOfFriends / 10 + 1;
		} else {
			mainLightLight.intensity = 0.5f;
		}
	}
}
