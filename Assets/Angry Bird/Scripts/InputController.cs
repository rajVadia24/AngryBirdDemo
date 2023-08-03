using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class InputController : MonoBehaviour
{
	private ThrowableInputActions throwableInputAction;
	
	public static InputController Instance;

	[SerializeField] private float dragThresold = 5f;

	private Camera mainCamera;

	private void Awake()
	{
		if (Instance == null)
			Instance = this;
		mainCamera = Camera.main;
		throwableInputAction = new ThrowableInputActions();
		throwableInputAction.Enable();
		throwableInputAction.Throwable.Throw.performed += Grab;
		throwableInputAction.Throwable.Throw.canceled += Release;
		throwableInputAction.Throwable.Ablilty.performed += SingleTap;
	}

	private void SingleTap(InputAction.CallbackContext obj)
	{
		Events.onTap?.Invoke();
	}

	private void OnDestroy()
	{
		throwableInputAction.Throwable.Throw.performed -= Grab;
		throwableInputAction.Throwable.Throw.canceled -= Release;
		throwableInputAction.Disable();
	}

	private void Release(InputAction.CallbackContext obj)
	{
		Events.onRelease?.Invoke();
	}

	private void Grab(InputAction.CallbackContext obj)
	{
		Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit))
		{
			if(hit.collider != null)
			{
				StartCoroutine(DragUpdate(hit.collider.gameObject));
			}
		}
	}

	private IEnumerator DragUpdate(GameObject clickObject)
	{
		float initialDistance = Vector3.Distance(clickObject.transform.position, mainCamera.transform.position);
		while(throwableInputAction.Throwable.Throw.ReadValue<float>() != 0)
		{
			Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
			Vector3 draggedValue  = ray.GetPoint(initialDistance) - clickObject.transform.position;
			if (draggedValue.magnitude > dragThresold)
			{
				draggedValue.x = 0;
				Events.	onGrab?.Invoke(draggedValue);
			}
			yield return new WaitForFixedUpdate();
		}
	}



}
