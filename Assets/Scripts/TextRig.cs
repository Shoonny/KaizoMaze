
using System;
using UnityEngine;
using UnityEngine.UI;



 /* The TextRig class basically manage the text of scores that is
    displayed in the game by using Multiple boolean parameters to determine the points to be displayed
    We try to make all the text script in one class */



public class TextRig : MonoBehaviour
{
	//The GameObject that attaches to this script;
	public GameObject GO ;

	//The boolean parameter used to detemine whether it is the finish screen or not;
	public bool IsFinish = false;

	//The Number that needs to be properly displayed;
	private  int  PointsToBeDisPlayed;

	//The boolean parameter used to determine whether it is the stage menu screen or not;
	public bool IsStageMenu = false;
	
	
	 /* The Update method is called once per frame automatically
	    by the UnityEngine
	    In this case the update is used to display 
	    the score properly refering to current scene*/
	
	
	void Update ()
	{
		
		
		/*if the player is shoot, it should be the finish scene that is loaded but the score is invalid 
		  for the player did not finish the whole stage without being shot
		*/
		if (Player.IsShoot&&!IsStageMenu)
		{
			
			GO.GetComponent<Text>().text = "Stage failed";
			return;

		}
		
		
		/*if the player is in the stage scene ,the highest score of each stage should be displayed
		 refering to the static parameter"current" in the player class*/
		 if (!IsFinish)
		{
			//Read the file before the scores are displayed
			FileIO.FileReader();
			Debug.Log(Convert.ToString(FileIO.AllPoints[0]));
			Debug.Log(Convert.ToString(FileIO.AllPoints[1]));
			//control the points that need to be displayed via switch case 
			switch (Player.CurrentStage)
			{
				case 1:
					this.PointsToBeDisPlayed = FileIO.AllPoints[0];
					break;
				case 2:
					this.PointsToBeDisPlayed = FileIO.AllPoints[1];
					break;
				
					
			}
			GO.GetComponent<Text>().text = "highScore: " + Convert.ToString(this.PointsToBeDisPlayed);

		/*if the player finished the whole stage without being shot than the UI should
		 tell the player about the current score */
		}
		else 

		{
			
			this.PointsToBeDisPlayed = Player.Points;
			GO.GetComponent<Text>().text = "SCore:" + Convert.ToString(this.PointsToBeDisPlayed);
		}
		
	}
}
