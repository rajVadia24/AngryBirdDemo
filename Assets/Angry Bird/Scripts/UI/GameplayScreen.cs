using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameplayScreen : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI mainScore;
	private float totalScore;

	private void OnEnable()
	{
		Events.onScoreAdded += AddScore;
	}
	private void OnDisable()
	{
		Events.onScoreAdded -= AddScore;
	}

	private void Start()
	{
		totalScore = 0f;
	}

	private void AddScore(float value)
	{
		totalScore += value;	
		mainScore.text = totalScore.ToString();
	}

}
