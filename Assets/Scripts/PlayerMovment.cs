using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment: MonoBehaviour
{

	public float acceleration;

	public float maxSpeed;

	private Rigidbody rigidBody;

//	private KeyCode[] inputKeys;

//	private Vector3[] directionForKeys;
	
	
	
	// Use this for initialization
	void Start ()
	{
//		inputKeys = new KeyCode[] {KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D};

//		directionForKeys = new Vector3[] {Vector3.forward, Vector3.left, Vector3.back, Vector3.right};

		rigidBody = GetComponent<Rigidbody>();
		

	}
	
	
	void FixedUpdate () {
		
		
	//The code below is used to run the test on computers
	
		
		
		
		
//		for (int i = 0; i < inputKeys.Length; i++)
//		{
//			var key = inputKeys[i];

//			if (Input.GetKey(key))
//			{
//			Vector3 movement = directionForKeys[i] * acceleration * Time.deltaTime;
//				movePlayer(movement);
//			}
//		}
	
		
		
		
		
		Vector3 movement = Vector3.zero;
		
		movement.x = 2* Input.acceleration.x * acceleration * Time.deltaTime;
		movement.z = 2*Input.acceleration.y * acceleration * Time.deltaTime;
		
		movePlayer(movement);
       


}

	void movePlayer(Vector3 movement)
	{
		if (rigidBody.velocity.magnitude * acceleration > maxSpeed)
		{
			rigidBody.AddForce(movement * -1);
		}
		else
		{
			rigidBody.AddForce(movement);
		}
		
	}
	
}
