using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Thrower : MonoBehaviour
{
	[SerializeField] private Transform _originPoint;
	[SerializeField] private float maxStretchRadius;
	public Throwables _currentThrowable;

	private Vector3 _intialPosition;

	private void OnEnable()
	{
		InputController.OnGrab += Aim;
		InputController.OnRelease += Throw;
	}

	private void OnDisable()
	{
		InputController.OnGrab -= Aim;
		InputController.OnRelease -= Throw;
	}
	private void Aim(Vector3 mousePos)
	{
	/*	Debug.Log(Vector3.Distance(_currentThrowable.transform.position, _originPoint.position));
		if (Vector3.Distance(_currentThrowable.transform.position, _originPoint.position) > maxStretchRadius)
		{
			Vector3 direction = (_currentThrowable.transform.position - _originPoint.position).normalized;
			_currentThrowable.transform.position = _originPoint.position + direction * maxStretchRadius;
		}
		else
		{
		}*/
			_currentThrowable.DragPlayer(mousePos);
	}

	private void Throw()
	{
		Vector3 dir = (_currentThrowable.transform.position - _originPoint.position).normalized;
		_currentThrowable.Throw(dir, _currentThrowable._force);
	}

}
