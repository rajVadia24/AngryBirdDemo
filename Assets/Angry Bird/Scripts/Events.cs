using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Events 
{
	#region Input Events
	public delegate void OnThrowableGrabbed(Vector3 dragValue);
	public static OnThrowableGrabbed onGrab;

	public delegate void OnThrowableReleased();
	public static OnThrowableReleased onRelease;

	public delegate void OnSingleTap();
	public static OnSingleTap onTap;
	#endregion

	public delegate void OnScoreAdded();
	public static OnScoreAdded onScoreAdded;

	#region Throwable Events
	public delegate void OnThrowableHit();
	public static OnThrowableHit onThrowableHitted;
	#endregion
}
