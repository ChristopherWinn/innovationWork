using UnityEngine;
using System.Collections;

public class cameraControl : MonoBehaviour {

	private Camera mainCamera;
	private Transform cameraTransform ;
	public Vector3 cameraPosition;

	private GameObject player;
	private Transform playerTransform;
	public Vector3 playerPosition;

	private GameObject gameManager;
	private gameManager gameManagerScript;

	// Use this for initialization
	void Start () 
	{
		mainCamera = Camera.main;
		cameraTransform = mainCamera.transform;

		player = GameObject.Find ("player");
		playerTransform = player.GetComponent<Transform>();

		gameManager = GameObject.Find ("gameManager");
		gameManagerScript = gameManager.GetComponent <gameManager> ();
	}
	
	// Update is called once per frame
	void Update () 
	{

		playerPosition = playerTransform.position;

	}

	void LateUpdate ()
	{
		if (playerPosition.z <= -9) 
		{
			Vector3 temp = cameraTransform.position;
			temp.z = -9;
			temp.x = playerTransform.position.x;
			cameraTransform.position = temp;
		} else {
			cameraTransform.position = new Vector3 (playerPosition.x,20,playerPosition.z);
		}

		Vector3 cameraY = cameraTransform.position;
		cameraY.y = 10 + gameManagerScript.numberOfFriends *2;
		cameraTransform.position = cameraY;
	}
}
