using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwables : MonoBehaviour
{
	public float _force;
	public float dragMaxSpeed = 1f;
	public ThrowableState _state;

	private bool isHitted = false;
	[SerializeField] protected bool usedAbility = false;
	protected Rigidbody rb;
	private ParticleSystem _destoryParticle;

	[SerializeField] private Transform resetPoint;

	private void Start()
	{
		Events.onTap += UseAblities;
		_destoryParticle = GetComponentInChildren<ParticleSystem>();
		rb = GetComponent<Rigidbody>();
		rb.isKinematic = true;
		rb.drag = 0;
		ChangeThrowableState(ThrowableState.Idle);
	}
	public void DragPlayer(Vector3 dragValue)
	{
		if(_state == ThrowableState.Loaded)
		{
			rb.isKinematic = false;
			rb.velocity = dragValue * dragMaxSpeed;
		}
	}
	public void Throw(Vector3 direction,float force)
	{
		if(_state == ThrowableState.Loaded)
		{
			rb.velocity = -direction * force;
			ChangeThrowableState(ThrowableState.Shooting);
		}
	}

	public virtual void UseAblities() { }

	public float CalculateImapactForce()
	{
		return rb.velocity.magnitude/Time.deltaTime;
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (_state == ThrowableState.Collapse) return;
		Obstacle o = collision.gameObject.GetComponent<Obstacle>();
		if (o != null)
		{
			ChangeThrowableState(ThrowableState.Collapse);
		}
		if (!isHitted)
		{
			rb.drag = 1.5f;
			Events.onThrowableHitted?.Invoke();
			isHitted = true;
			StartCoroutine(DestroyThrowable());
		}
	}
	public void ChangeThrowableState(ThrowableState state)
	{
		switch(state)
		{
			case ThrowableState.Idle:
				this._state = ThrowableState.Idle;
				break;
			case ThrowableState.Loaded:
				this._state = ThrowableState.Loaded;
				break;
			case ThrowableState.Shooting:
				this._state = ThrowableState.Shooting;
				break;
			case ThrowableState.Collapse:
				this._state = ThrowableState.Collapse;
				break;
		}
	}
	private IEnumerator DestroyThrowable()
	{
		yield return new WaitForSeconds(2f);
		gameObject.GetComponent<MeshRenderer>().enabled = false;
		_destoryParticle.Play();
		yield return new WaitForSeconds(0.5f);
		gameObject.SetActive(false);
	}
	private void OnDisable()
	{
		Events.onTap -= UseAblities;
		StopAllCoroutines();
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
public enum ThrowableState
{
	None,
	Idle,
	Loaded,
	Shooting,
	Collapse,
}
