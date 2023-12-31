using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
	public FloatVariable myPoint;

	private void OnCollisionEnter(Collision collision)
	{
		Throwables t = collision.gameObject.GetComponent<Throwables>();
		if(t != null )
		{
			Vector3 relativeVelocity = collision.relativeVelocity;
			float impactForce = relativeVelocity.magnitude/Time.deltaTime;
			if( impactForce > 1000f )
			{
				Events.onScoreAdded?.Invoke(myPoint.initialValue);
				StartCoroutine(DisableObstacle());
			}
		}
	}

	private IEnumerator DisableObstacle()
	{
		yield return new WaitForSeconds(1.5f);
		gameObject.SetActive(false);
	}

	private void OnDisable()
	{
		StopAllCoroutines();
	}

}
