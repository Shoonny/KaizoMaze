using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * The label class is the script that provides the on real-time score displaying and the buttons for
 * pausing and God mode
 * For the God mode ,it stops the enemy's shooting method from calling.which provides a clear way while presenting
 * In this class ,pause screen and the pause-resume function is implemented
 * However the count down after tapping resume is not implemented
 * and we wish to complete it in the further development 
 */
public class Label : MonoBehaviour
{
	//The texture used to carry the pause button
	public Texture Pause;
	
	//the GUISkin that offers basic settings of labels fonts and backgrounds
	public GUISkin GUI1;

	//public GUISkin GUI2;
	
	public Texture Background;
	
	//The parameter to determine if it's currently paused
	private Boolean IsPause = false;

	//private String CountdownNumbers = "";

	private bool FromPause = false;

	//public float SecondsToWait = 1;

	private int btnCount = 1;
	//The string that shows if the godmode is on
	private string godmode = "Godmode: off";

	void Start()
	{
		this.btnCount = 1;
	}

	 void OnGUI()
	 {
		 GUI.skin = GUI1;


		 if (!IsPause)
		 {
			GUI.Label(new Rect(Screen.width*0.85f,Screen.height*0.1f,Screen.width*0.1f, Screen.width*0.1f), Convert.ToString(Player.Points));
		  //  GUI.Label(new Rect(Screen.width*0.5f,Screen.height*0.5f,Screen.width*0.4f, Screen.width*0.4f),CountdownNumbers );
			 if (GUI.Button(new Rect(Screen.width * 0.3f, Screen.height * 0.05f, Screen.width * 0.5f, Screen.height * 0.2f),godmode
				 ))
			 {
				 /*
				  * The counter is used to control the god mode on and off
				  * We concerned that this button may be tapped more than once to persistently change
				  * between the normal mode and the god mode,so we used a counter to determine whether it should be turned
				  * off or on
				  */
				 if (btnCount % 2 != 0)
				 {
					 godmode = "godmode: on";
					 Shooting.IsGodMode = true;
					 
				 }
				 else
				 {
					 godmode = "godmode: off";
					 Shooting.IsGodMode = false;
				 }

				 btnCount++;
			 }
			 if (GUI.Button(new Rect(Screen.width*0.05f, Screen.height*0.05f, Screen.width*0.15f, Screen.width*0.15f), Pause))
			 {
				 IsPause = true;
				 
				 Time.timeScale = 0;
			 }

			 if (FromPause)
			 {
				 
				 FromPause = false;
			//	StartCoroutine( Wait(SecondsToWait));
				 Time.timeScale = 1;
			 } 
		 }

		 if (IsPause)
		 {
			 GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Background);
			 if (GUI.Button(new Rect(Screen.width*0.35f, Screen.height*0.2f, 400, 100), "RESUME"))
			 {
				 IsPause = false;
				// Time.timeScale = 1;
				 FromPause = true;
			 }

			 if (GUI.Button(new Rect(Screen.width*0.35f,Screen.height*0.35f, 400, 100), "REtry"))
			 {
				 Time.timeScale = 1;
				 switch (Player.CurrentStage)
				 {
						 case 1:
							 SceneManager.LoadScene("Main");
							 break;
						 case 2:
							 SceneManager.LoadScene("Main2");
							 break;
							 
				 }
			 }

			 if (GUI.Button(new Rect(Screen.width*0.35f, Screen.height*0.5f, 500, 100), "Main menu"))
			 {
				 Time.timeScale = 1;
				 SceneManager.LoadScene("Menu");
			 }

			 if (GUI.Button(new Rect(Screen.width*0.35f, Screen.height*0.65f, 400, 100), "Stages"))
			 {
				 Time.timeScale = 1;
				 SceneManager.LoadScene("Stages");
			 }



		 }
	 }

	
	/*
	 * The following code is about the incompleted  count down function
	 */
	
	
	
	
//	IEnumerator Wait(float Seconds)
//	{
//		yield return new WaitForSeconds(Seconds);
//		CountdownNumbers = "3";
//		yield return new WaitForSeconds(Seconds);
	  
				 
				 
//		CountdownNumbers = "2";
//		yield return new WaitForSeconds(Seconds);

//		CountdownNumbers = "1";
//		yield return new WaitForSeconds(Seconds);

//		CountdownNumbers = "GO";
//		yield return new WaitForSeconds(Seconds);

//		CountdownNumbers = "";
//		Time.timeScale = 1;

//	}

}
