using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
	[SerializeField] private Thrower thrower;
	public List<Throwables> throwables;
	public List<Enemy> enemies;

	private  Throwables currentThrowable;
	private int _currentThrowableIndex;
	private float totalScore = 0;

	private void OnEnable()
	{
		Events.onThrowableHitted += CheckForLevelCompletion;
		Events.onScoreAdded += CalculateScore;
	}


	private void OnDisable()
	{
		Events.onThrowableHitted -= CheckForLevelCompletion;
		Events.onScoreAdded -= CalculateScore;
	}
	private void Start()
	{
		thrower = GetComponentInChildren<Thrower>();
		totalScore = 0;
	}
	public void StartLevel()
	{
		//initialize Enemy state
		foreach (Enemy enemy in enemies)
		{
			enemy.enemyState = EnemyState.Alive;
		}
		//initialize throwable state
		for(int i = 0; i < throwables.Count; i++)
		{
			throwables[i].ChangeThrowableState(ThrowableState.Idle);		
		}
		currentThrowable = throwables[0];
		_currentThrowableIndex = 0;
		StartCoroutine(thrower.SetCurrentThrowable(currentThrowable));	
	}
	public void EndLevel()
	{

	}
	private void PlaceNextThrowable()
	{
		_currentThrowableIndex++;
		StartCoroutine(thrower.SetCurrentThrowable(throwables[_currentThrowableIndex]));
	}
	private void CheckForLevelCompletion()
	{
		StartCoroutine(CheckAllEnemiesState());
	}
	private void CalculateScore(float value)
	{
		totalScore += value;
	}
	private IEnumerator CheckAllEnemiesState()
	{
		yield return new WaitForSeconds(3f);
		if (IsAlive())
		{
			if (IsThrowableLeft())
				PlaceNextThrowable();
			else
				Debug.Log("Game Over");
		}
		else
		{
			Debug.Log("LevelComplete");
			Events.onLevelCompleted?.Invoke(totalScore);
		}
	}
	bool IsAlive()
	{
		foreach (Enemy enemy in enemies)
		{
			if (enemy.enemyState == EnemyState.Alive)
				return true;
		}
		return false;
	}
	bool IsThrowableLeft()
	{
		foreach(Throwables t in throwables)
		{
			if(t._state == ThrowableState.Idle)
				return true;
		}
		return false;
	}
}
