using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyState enemyState;

	private void OnCollisionEnter(Collision collision)
	{
		Vector3 relativeVelocity = collision.relativeVelocity;
		float impactForce = relativeVelocity.magnitude / Time.deltaTime;
		Debug.Log("Enemy impact Force: " + impactForce);
		if(impactForce > 100f)
		{
			enemyState = EnemyState.Dead;
			gameObject.SetActive(false);
		}
	}
}

public enum EnemyState
{
    None,
    Alive,
    Dead,
}
