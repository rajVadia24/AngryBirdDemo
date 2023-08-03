using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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
		Events.onGrab += Aim;
		Events.onRelease += Throw;
	}

	private void OnDisable()
	{
		Events.onGrab -= Aim;
		Events.onRelease -= Throw;
	}
	private void Aim(Vector3 mousePos)
	{
		_currentThrowable.DragPlayer(mousePos);
	}

	private void Throw()
	{
		Vector3 dir = (_currentThrowable.transform.position - _originPoint.position).normalized;
		_currentThrowable.Throw(dir, _currentThrowable._force);
	}


	public IEnumerator SetCurrentThrowable(Throwables t)
	{
		yield  return new WaitForSeconds(1);
		_currentThrowable = t;
		_currentThrowable.transform.position = _originPoint.position;
		_currentThrowable.ChangeThrowableState(ThrowableState.Loaded);
	}

}
