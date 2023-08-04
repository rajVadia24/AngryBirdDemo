using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyState enemyState;
	public FloatVariable myPoint;

	private void OnCollisionEnter(Collision collision)
	{
		Vector3 relativeVelocity = collision.relativeVelocity;
		float impactForce = relativeVelocity.magnitude / Time.deltaTime;
		Debug.Log("Enemy impact Force: " + impactForce);
		if(impactForce > 50f)
		{
			enemyState = EnemyState.Dead;
			Events.onScoreAdded?.Invoke(myPoint.initialValue);
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
