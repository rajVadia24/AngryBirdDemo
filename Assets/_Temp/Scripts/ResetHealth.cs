using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetHealth : MonoBehaviour
{
    public FloatVariable health;
    public FloatVariable maxHealth;

    public GameEvent RestartEvent;
    void Start()
    {
        if(health.value != maxHealth.value)
        { 
            health.value = maxHealth.value;
        }
    }

	private void OnTriggerEnter(Collider other)
	{
        RestartEvent.Raise();
	}

    public void ResetPlayerHealth()
    {
		health.value = maxHealth.value;
	}

}
