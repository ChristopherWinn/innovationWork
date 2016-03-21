using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour {

	private GameObject player;
	private Transform playerTransform;
	private moveCube playerScript;

	[SerializeField] private float timeSpentOnHex1;
	[SerializeField] private bool hex1Drained;
	private GameObject hex1Cover;
	private Transform hex1CoverTransform;

	[SerializeField] GameObject hex1Child;
	private GameObject hex1GlowOutline;
	private MeshRenderer hex1GlowRender;
	bool hexChild1Spawn = true;
	bool hexChild2Spawn = true;
	bool hexChild3Spawn = true;
	bool hexChild4Spawn = true;

	public float numberOfFriends;


	// Use this for initialization
	void Start () 
	{
		player = GameObject.Find ("player");
		playerTransform = player.GetComponent <Transform>();
		playerScript = player.GetComponent <moveCube>();

		hex1Drained = false;
		hex1Cover = GameObject.Find ("hex1Cover");
		hex1CoverTransform = hex1Cover.transform;
		hex1GlowOutline = GameObject.Find ("hex1GlowOutline");
		hex1GlowRender = hex1GlowOutline.GetComponent <MeshRenderer> ();
		hex1GlowRender.enabled = false;

		timeSpentOnHex1 = 2;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// HEX1 //
		if (playerScript.onHex1 == true && hex1Drained == false) {
			timeSpentOnHex1 -= Time.deltaTime / 4;
			hex1GlowRender.enabled = true;
		} else {
			hex1GlowRender.enabled = false;
		}

		if (timeSpentOnHex1 <= 0) 
		{
			timeSpentOnHex1 = 0;
			hex1Drained = true;
		}

		if (hex1Drained == false) 
		{
			hex1CoverTransform.localPosition = new Vector3 (0, 0, timeSpentOnHex1);
		}


		if (timeSpentOnHex1 <= 1.9 && hexChild1Spawn == true) 
		{
			GameObject hexChild;

			hexChild = Instantiate (hex1Child, playerTransform.position, Quaternion.identity) as GameObject;

			hexChild.transform.SetParent (playerTransform);

			numberOfFriends += 1;

			hexChild1Spawn = false;

		}
		if (timeSpentOnHex1 <= 1.4 && hexChild2Spawn == true) 
		{
			GameObject hexChild;
			
			hexChild = Instantiate (hex1Child, playerTransform.position, Quaternion.identity) as GameObject;
			
			hexChild.transform.SetParent (playerTransform);

			numberOfFriends += 1;

			hexChild2Spawn = false;

		}
		if (timeSpentOnHex1 <= 0.9 && hexChild3Spawn == true) 
		{
			GameObject hexChild;
			
			hexChild = Instantiate (hex1Child, playerTransform.position, Quaternion.identity) as GameObject;
			
			hexChild.transform.SetParent (playerTransform);

			numberOfFriends += 1;

			hexChild3Spawn = false;

		}
		if (timeSpentOnHex1 <= 0.4 && hexChild4Spawn == true) 
		{
			GameObject hexChild;
			
			hexChild = Instantiate (hex1Child, playerTransform.position, Quaternion.identity) as GameObject;
			
			hexChild.transform.SetParent (playerTransform);

			numberOfFriends += 1;

			hexChild4Spawn = false;
		
		}

		if (hex1Drained == true) 
		{
			GameObject hex1pool = GameObject.Find ("hex1");
			Destroy (hex1pool);
			Destroy (hex1Cover);
		}
		//////
	}
}
