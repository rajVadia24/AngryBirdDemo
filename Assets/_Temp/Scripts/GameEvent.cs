using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameEvent : ScriptableObject
{
	private List<GameEventListeners> eventListeners = new List<GameEventListeners>();

	public void Raise()
	{
		for(int i =0; i < eventListeners.Count; i++)
		{
			eventListeners[i].OnEventRaised();
		}
	}

	public void RegisterListener(GameEventListeners listener) 
	{
		if(!eventListeners.Contains(listener)) eventListeners.Add(listener);
	}

	public void UnRegisterListener(GameEventListeners listener)
	{
		if(eventListeners.Contains(listener)) eventListeners.Remove(listener);
	}
}
