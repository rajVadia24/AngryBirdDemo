using InputSamples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
	public LevelDataSO levelDataSO;
	[SerializeField] private int currentlevelIndex;

	private Level currentLevel;
	public float currentLevelHighScore;

	private void Start()
	{
		SaveLoadSystem.LoadData(levelDataSO);
		Events.onLevelCompleted += CheckForHighscore;
	}

	private void OnApplicationQuit()
	{
		SaveLoadSystem.SaveData(levelDataSO);
	}

	[ContextMenu("Load Level")]
	public void LoadLevel()
	{
		LoadLevel(currentlevelIndex);
	}

	public void LoadLevel(int levelIndex = -1)
	{
		if(levelIndex > -1)
		{
			currentLevel = Instantiate(levelDataSO.levelData[levelIndex].level,transform.position,Quaternion.identity);
			currentLevelHighScore = levelDataSO.levelData[levelIndex].levelHighScore;
			currentLevel.StartLevel();
		}
		else
		{
			currentLevel = Instantiate(levelDataSO.levelData[currentlevelIndex].level, transform.position, Quaternion.identity);
			currentLevelHighScore = levelDataSO.levelData[currentlevelIndex].levelHighScore;
			currentLevel.StartLevel();
		}
	}

	private void CheckForHighscore(float levelScore)
	{
		levelDataSO.CheckFortheHighScore(currentlevelIndex, levelScore);
	}

	[ContextMenu("Unload Level")]
	void UnloadLevel()
	{
		if(currentLevel != null) 
			Destroy(currentLevel.gameObject);
	}

}
