using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuntimeSets<T> : ScriptableObject
{
	public List<T> Sets = new List<T>();

	public void AddItem(T obj)
	{
		if(!Sets.Contains(obj))
			Sets.Add(obj);
	}

	public void RemoveItem(T obj) 
	{ 
		if (Sets.Contains(obj))			
			Sets.Remove(obj); 
	}
}
