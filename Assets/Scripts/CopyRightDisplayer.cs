using System;
using UnityEngine;
using UnityEngine.UI;


/*
 * This class is designed to display the copy right imformation based on Singleton Pattern
 * Only one instance of the displayer is allowed to exist
 */



public class CopyRightDisplayer : MonoBehaviour {

	public  GameObject GO;

	private CopyRightDisplayer()
	{
		
	}

	private static CopyRightDisplayer crd = null;

	public  static CopyRightDisplayer GetCopyRights()
	{
		if (crd == null)
		{
			
			crd = new CopyRightDisplayer();
		}

		return crd;
	}

	private  String GetCopyRightInfo()
	{
		return "CopyRight © 2018 \nZhuYH,ZhangJH,ZhouWJ.All Rights Reserved";
	}
	void Update()
	{
		CopyRightDisplayer re = CopyRightDisplayer.GetCopyRights();
		GO.GetComponent<Text>().text = re.GetCopyRightInfo();
	}
}
