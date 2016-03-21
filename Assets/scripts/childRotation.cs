using UnityEngine;
using System.Collections;

public class childRotation : MonoBehaviour {
	
	private GameObject child;
	private Transform myTransform;
	private float rotationSpeed;
	private float orbitRadius;
	private float spawnScaling;

	private GameObject gameManager;
	private gameManager gameManagerScript;
	private float lifeCycle;
	private bool lifeCycleLive;
	private GameObject particles;

	[SerializeField] private GameObject timeOutParticle;

	// Use this for initialization
	void Start () 
	{
		child = this.gameObject;
		myTransform = child.transform;
		rotationSpeed = Random.Range (10, 90);
		orbitRadius = Random.Range (10, 20);
		spawnScaling = 0;
		myTransform.localScale = new Vector3 (0,0,0);

		myTransform.Translate (Vector3.right * orbitRadius/10);

		gameManager = GameObject.Find ("gameManager");
		gameManagerScript = gameManager.GetComponent <gameManager> ();

		lifeCycle = 30;

		lifeCycleLive = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		myTransform.Rotate (Vector3.one * Time.deltaTime*rotationSpeed);
		myTransform.localScale = new Vector3 (spawnScaling/10, spawnScaling/10, spawnScaling/10);

		if (spawnScaling <= 2) 
		{
			spawnScaling += Time.deltaTime*2;
		}

		lifeCycle -= Time.deltaTime;

		if (lifeCycle <= 0 && lifeCycleLive == true) 
		{
			gameManagerScript.numberOfFriends -= 1;
			lifeCycleLive = false;
		}

		if (lifeCycleLive == false) 
		{
			particles = Instantiate (timeOutParticle, myTransform.position, Quaternion.identity) as GameObject;

			Destroy (particles, 1);

			Destroy (child);
		}

	}
}
