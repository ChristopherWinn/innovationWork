using UnityEngine;
using System.Collections;

public class moveCube : MonoBehaviour {

	private float moveHorizontal;
	private float moveVertical;
	private Rigidbody myRigidBody;

	private GameObject hex1;
	public bool onHex1;
	
	[SerializeField] private float movementSpeed;
	
	void Start () 
	{
		myRigidBody = this.gameObject.GetComponent<Rigidbody> ();
	
		hex1 = GameObject.Find ("hex1");
		onHex1 = false;

	}
	
	// Update is called once per frame
	void Update () 
	{
		moveVertical = Input.GetAxis ("Vertical");
		moveHorizontal = Input.GetAxis ("Horizontal");
		
		Vector3 movement = new Vector3 (moveHorizontal, 0f, moveVertical);
		
		myRigidBody.velocity = movement * movementSpeed;
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject == hex1)
		{
			onHex1 = true;
		}
	}

	void OnTriggerExit (Collider col)
	{
		if (col.gameObject == hex1) 
		{
			onHex1 = false;
		}
	}
}