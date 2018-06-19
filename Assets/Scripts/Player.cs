using System.Collections;
using System.Collections.Generic;

using UnityEngine;

/**
 *　　　　　　　 ┏┓　 ┏┓+ +
 *　　　　　　　┏┛┻━━━┛┻┓ + +
 *　　　　　　　┃　　　　　　┃ 　
 *　　　　　　　┃　　　━　　 ┃ ++ + + +
 *　　　　　　 ████━████  ┃+
 *　　　　　　　┃　　　　　　　┃ +
 *　　　　　　　┃　　　┻　　　┃
 *　　　　　　　┃　　　　　　┃ + +
 *　　　　　　　┗━┓　　　┏━┛
 *　　　　　　　　 ┃　　　┃　　　　　　　　　　　
 *　　　　　　　　 ┃　　　┃ + + + +
 *　　　　　　　　 ┃　　　┃　　　　Code is far away from bug with the animal protecting　　　　　　　
 *　　　　　　　　 ┃　　　┃ + 　　　　神兽保佑,代码无bug　　
 *　　　　　　　　 ┃　　　┃
 *　　　　　　　　 ┃　　　┃　　+　　　　　　　　　
 *　　　　　　　　 ┃　 　 ┗━━━┓ + +
 *　　　　　　　　 ┃ 　　　　   ┣┓
 *　　　　　　　　 ┃ 　　　　　 ┏┛
 *　　　　　　　　 ┗┓┓┏━┳┓┏┛ + + + +
 *　　　　　　　　  ┃┫┫ ┃┫┫
 *　　　　　　　　  ┗┻┛ ┗┻┛+ + + +
 */










/*
 * The player class is designed to store the data and the logicall relationships between
 * the sphere controled by the player and other part of the game
 * Including the integer "Points" that shows the current score made by the player
 * the boolean "IsShoot" that shows the status of whether the player is hit by the bullets
 * In this class,we try to implement the real-time points adding up through detecting the collision
 * happens between the sphere and the enemy cubes.Exceptionally, when the sphere collide with the clinder,the finish
 * scene will be loaded
 * The integer CurrentStage is an important parameter that it guides related text controling scripts to display the
 * proper score as well as providing index while doing file IO
 */


public class Player : MonoBehaviour
{
	public static int Points = 0;
	
	public static bool IsShoot = false;

	public static int CurrentStage = 1;
	
	void Start ()
	{
		//Everytime when the player is initialized ,current score and the status of being shot are refreshed
		Points = 0;
		IsShoot = false;
		
	}
	
	void collidedWithTarget(Target tar)
	{
		//Make sure when collision is happening between the player and the terrain the function has solutions
		//Since the terrain is not attached to "Target" script , when the collision happens,the object "tar" is null.
		if (tar == null)
		{
			return;
		}

		if (tar.IsFinal)
		{
			tar.Panggg(this);
			return;
		}
		tar.Panggg(this);
		Points ++;
	}

	private void OnCollisionEnter(Collision col)
	{
		Target tar = col.collider.gameObject.GetComponent<Target>();
		collidedWithTarget(tar);

	}

	
}
