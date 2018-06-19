using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Projectile : MonoBehaviour
{
	public float speed;

	private Vector3 shootDirection;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	 void FixedUpdate()
	 {
		 this.transform.Translate(shootDirection * speed, Space.World);
	 }

	public void FireProjectile(Ray ray)
	{
		this.shootDirection = ray.direction;
		this.transform.position = ray.origin;
		rotateInShootDirection();
		
	}

	 void OnCollisionEnter(Collision col)
	 {
		 Player player = col.collider.gameObject.GetComponent<Player>();
		 if (player)
		 {
			 Player.IsShoot = true;
			 SceneManager.LoadScene("Finish");
		 }

		 Destroy(this.gameObject);
	 }
	void rotateInShootDirection() {
		Vector3 newRotation = Vector3.RotateTowards(transform.up, shootDirection, 0.01f, 0.0f);
		transform.rotation = Quaternion.LookRotation(newRotation);
	}
}
