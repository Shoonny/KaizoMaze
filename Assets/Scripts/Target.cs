
using UnityEngine;
using UnityEngine.SceneManagement;


/*
 * The class is designed to store and implement the data and logicall bahaviours
 * related to cudes and clinders
 * We distinguished the clinders which is the end of each stage via the boolean parameter "IsFinal",which is modifiable
 * in the hierachy screen in unity
 */


public class Target : MonoBehaviour
{
	//The public integer controling speed of rotation
	public int Rotatespeed = 20;
	
	//The parameter used to distinguish the clinder from cubes
	public bool IsFinal = false;
	
	
	
	//This update function is meant to make the cube automaticlly rotate on the world's vertical axle
	private void Update () {
		this.transform.Rotate(Vector3.up * Rotatespeed,Space.World);
		
	}
	
	
	
	/*
	 * This funcion handle the problems when the collision happens between the player and other
	 * scripted game objects 
	 */
	public void Panggg(Player player)
	{
		//if the collision happens between the player and the ordinary cubes ,the cube shall disappear
		Destroy(this.gameObject);
		//if the collision happens between the sphere and the clinder ,then load the finish scene and write file
		if (IsFinal)
		{
			Player.IsShoot = false;
			FileIO.FileWriter();
			SceneManager.LoadScene("Finish");
		}
	}
}
