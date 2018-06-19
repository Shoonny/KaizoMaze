using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;





public class Shooting : MonoBehaviour
{
	public Projectile projectilePrefabs;
	private int counter = 0;
	public LayerMask mask;

	public static bool IsGodMode = false;
	// Use this for initialization
	void Start () {
		
	}

	void shoot()
	{
		var projectile = Instantiate(projectilePrefabs).GetComponent<Projectile>();
		var direction = new Vector3((float)Math.Sin(Time.timeSinceLevelLoad / 2.0 + this.transform.position.x),0,
			-(float)Math.Cos(Time.timeSinceLevelLoad / 2.0 + this.transform.position.x));
		var shootRay = new Ray(this.transform.position,direction);
		
		
		projectile.FireProjectile(shootRay);
		
	}
	void FixedUpdate ()
	{
		counter++;
		if (!IsGodMode&&(counter % 12 == 0))
		{
			
				shoot();
		}
	}
}
