using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwables : MonoBehaviour
{
	public float _force;
	public float dragMaxSpeed = 1f;
	private Rigidbody rb;


	[SerializeField] private Transform resetPoint;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		rb.isKinematic = true;
	}

	public void DragPlayer(Vector3 dragValue)
	{
		rb.isKinematic = false;
		rb.velocity = dragValue * dragMaxSpeed;
	}

	public void Throw(Vector3 direction,float force)
	{
		rb.velocity = -direction * force;
	}

#if UNITY_EDITOR
	[ContextMenu("ResetBall")]
	private void RepositionBall()
	{
		rb.isKinematic = true;
		rb.velocity = Vector3.zero;
		transform.position = resetPoint.position;
		transform.rotation = Quaternion.identity;	
	}
#endif
}
