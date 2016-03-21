using UnityEngine;
using System.Collections;

public class orbitRotation : MonoBehaviour {

	private GameObject child;
	private Transform myTransform;
	private float rotationSpeed;
	private float startRotation;


	// Use this for initialization
	void Start () 
	{
		child = this.gameObject;
		myTransform = child.transform;
		rotationSpeed = Random.Range (10, 40);
		startRotation = Random.Range (1, 360);

		myTransform.Rotate (0, startRotation, 0);
	}
	
	// Update is called once per frame
	void Update () 
	{
		myTransform.Rotate (Vector3.up * Time.deltaTime*rotationSpeed);
	}
}
