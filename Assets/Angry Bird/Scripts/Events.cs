using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Events 
{
	public delegate void OnScoreAdded();
	public static event OnScoreAdded onScoreAdded;

}
