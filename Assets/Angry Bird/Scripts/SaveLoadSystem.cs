using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoadSystem : MonoBehaviour
{
	private static  string saveFile;
	
	private void Awake()
	{
		saveFile = Application.persistentDataPath + "/AngryBirdData.json";
	}

	public static void SaveData(LevelDataSO data)
	{
		string gameData = JsonUtility.ToJson(data);
		File.WriteAllText(saveFile, gameData);
		Debug.Log("Data is Saved");
	}

	[ContextMenu("Load Data")]
	public static void LoadData(LevelDataSO data)
	{
		
		if (File.Exists(saveFile))
		{
			string filedata = File.ReadAllText(saveFile);
			Debug.Log(filedata);
		 JsonUtility.FromJsonOverwrite(filedata,data);

		}
		else
		{
			Debug.LogError("File Does not Exist");
		}
	}
}
