using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


/*
 * The FileIO class is used to store the highest score in each stage permanently by creating a file
 * And implement the function of comparing the current points with the highest scores stored in the file
 * The file created by the class is stored in the persistent data path in the mobile device
 * All the method in this class is static ,for as far as we concern that there is no necessary to create an object while
 * doing the file IO manuver
 */

public class FileIO : MonoBehaviour
{
	//Create a static list to store the scores
	public static List<int> AllPoints = new List<int>(2);
	
	/*
	 * The FileWriter is able to write the score to the file while the current score is higher than
	 * the one in the file, On the other hand it is able to create a new file if the score storing file is not
	 * exsit
	 */
	public static void FileWriter()
	{
		//The parameter that stores the current points
		int current = Player.Points;
		
		//The parameter that stores the current stage
		int currentStage = Player.CurrentStage;
		
		
		StreamWriter sw;
		FileInfo t = new FileInfo(Application.persistentDataPath+"//"+ "Score.kz");
		if(!t.Exists)
		{
			//Create a new file if it does not exist 
			//Write zero as the default number
			AllPoints.Add(0);
			AllPoints.Add(0);
			sw = t.CreateText();
			sw.WriteLine(AllPoints[0]);
			sw.WriteLine(AllPoints[1]);
			sw.Close();
			sw.Dispose();

		}
		
		
		/*
		 * According to the current stage parameter ,we are able to locate the score
		 * in the list through index and compare it with the current points of the stage
		 */
		else
		{
			//if the current point of the stage is higher than the point in the file 
			//than it will be writen into the file
			if (current > AllPoints[currentStage - 1])
			{
				AllPoints.Insert(currentStage - 1,current);
				sw = t.CreateText();
				sw.WriteLine(AllPoints[0]);
				sw.WriteLine(AllPoints[1]);
				sw.Close();
				sw.Dispose();

			}
		}


	}
	/*
	 * the FileReader method read the scores from the file and store them in the list
	 * created above
	 */
	public static void FileReader()
	{
		List<int> temo = new List<int>();
		StreamReader sr =null;
		try{
			sr = File.OpenText(Application.persistentDataPath+"//"+ "Score.kz");
			
		}catch(Exception e)
		{
			FileIO.FileWriter();
			
		}
		string line;
		int counter = 0;	
		
		while (counter < 2)
		{
			line = sr.ReadLine();
			int temp = (int)Convert.ToInt32(line);
			temo.Add(temp);
			counter++;
			
		}

		AllPoints = temo;




		sr.Close();
		
		sr.Dispose();
	}

	
	
}
