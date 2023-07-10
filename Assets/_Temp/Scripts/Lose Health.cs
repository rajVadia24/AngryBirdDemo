using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseHealth : MonoBehaviour
{
	public Slider healthBar;
	public FloatVariable health;
	public FloatVariable maxHealth;
	public GameEvent gameEvent;

	private void Start()
	{
		healthBar.value = health.value;
	}

	private void OnTriggerEnter(Collider other)
	{
		gameEvent.Raise();
	}

	public void ReduceHealth()
	{
		health.value -= 10f;
		healthBar.value =  health.value/maxHealth.value;
		if (health.value <= 0)
		{
			Destroy(this.gameObject);
			print("You Died");
		}
	}
}
