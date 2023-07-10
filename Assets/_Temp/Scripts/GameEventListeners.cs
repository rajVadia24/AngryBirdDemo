using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListeners : MonoBehaviour
{
	public GameEvent gameEvent;

	public UnityEvent response;

	private void OnEnable()
	{
		gameEvent.RegisterListener(this);
	}

	private void OnDisable()
	{
		gameEvent.UnRegisterListener(this);
	}

	public void OnEventRaised()
	{
		response.Invoke();
	}
}