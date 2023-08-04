using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData",menuName = "AngryBird/SO/LevelData")]
public class LevelDataSO : ScriptableObject
{
	public List<LevelData> levelData;


	public void CheckFortheHighScore(int LevelIndex,float Score)
	{
		if (levelData[LevelIndex].levelHighScore < Score)
		{
			levelData[LevelIndex].levelHighScore = Score;	
		}
	}
	
}

[Serializable]
public class LevelData
{
	public Level level;
	public float levelHighScore;
}

