using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	public LevelDataSO levelData;
	[SerializeField] private int currentlevelIndex;

	private Level currentLevel;

	[ContextMenu("Load Level")]
	public void LoadLevel()
	{
		LoadLevel(currentlevelIndex);
	}

	public void LoadLevel(int levelIndex = -1)
	{
		if(levelIndex > -1)
		{
			currentLevel = Instantiate(levelData.levels[levelIndex],transform.position,Quaternion.identity);
			currentLevel.StartLevel();
		}
		else
		{
			currentLevel = Instantiate(levelData.levels[currentlevelIndex], transform.position, Quaternion.identity);
			currentLevel.StartLevel();
		}
	}

	[ContextMenu("Unload Level")]
	void UnloadLevel()
	{
		if(currentLevel != null) 
			Destroy(currentLevel.gameObject);
	}

}
