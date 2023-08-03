using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData",menuName = "AngryBird/SO/LevelData")]
public class LevelDataSO : ScriptableObject
{
	public List<Level> levels;
}
