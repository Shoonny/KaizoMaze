using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
/*
 * The Camera rig class is used to make main camera stay focused on the sphere controled by the player
 * by assigning the script a valid instance of player
 */


public class CameraRig : MonoBehaviour
{
	public float moveSpeed;

	public GameObject target;

	private Transform rigTransform;
	
	
	void Start ()
	{
		rigTransform = this.transform.parent;
		
	}
	
	void FixedUpdate () {
		if (target == null)
		{
			return;
			
		}

		rigTransform.position = Vector3.Lerp(rigTransform.position, target.transform.position,Time.deltaTime * moveSpeed);

	}
}
