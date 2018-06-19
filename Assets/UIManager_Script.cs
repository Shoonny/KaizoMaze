using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.TestTools;

public class UIManager_Script : MonoBehaviour
{


	public Animator titleImage;
	public Animator MoreButton;
	public Animator PlayButton;
	public Animator Information;
	
	public void Tostages()
	{
		SceneManager.LoadScene("Stages");
	}

	public void BackToMainMenu()
	{
		SceneManager.LoadScene("Menu");
	}

	public void BackToStages()
	{
		FileIO.FileReader();
		SceneManager.LoadScene("Stages");
	}

	public void StartGame()
	{
		switch (Player.CurrentStage)
		{
				case 1:
					SceneManager.LoadScene("Main");
					break;
				case 2:
					SceneManager.LoadScene("Main2");
					break;
				default: break;
					
		}
	}

	public void OpenMoreInformation()
	{
		
		MoreButton.SetBool("IsClicked", true);
		titleImage.SetBool("IsClicked",true);
		PlayButton.SetBool("IsClicked",true);
		Information.SetBool("IsClicked",true);
		
		titleImage.SetBool("titleIsHidden",true);
		MoreButton.SetBool("MoreIsHidden",true);
		PlayButton.SetBool("PlayIsHidden",true);
		Information.SetBool("IsHidden",true);
		
	}

	public void CloseInformation()
	{
		titleImage.SetBool("titleIsHidden",false);
		MoreButton.SetBool("MoreIsHidden",false);
		PlayButton.SetBool("PlayIsHidden",false);
		Information.SetBool("IsHidden",false);
	}

	public void ChangeToStage1()
	{
		Player.CurrentStage = 1;
		
	}

	public void ChangeToStage2()
	{
		Player.CurrentStage = 2;
	}
	
}
