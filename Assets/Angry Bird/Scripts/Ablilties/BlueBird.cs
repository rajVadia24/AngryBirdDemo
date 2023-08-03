using UnityEngine;

public class BlueBird : Throwables
{
	[SerializeField] private GameObject childBirdPrefab;
	[SerializeField] private float spawnForce = 10f;

	public override void UseAblities()
	{
		if (_state == ThrowableState.Shooting)
		{
			if (!usedAbility)
			{
				base.UseAblities();
				for (int i = 0; i < 3; i++)
				{
					GameObject smallBird = Instantiate(childBirdPrefab, transform.position, Quaternion.identity,transform.parent);
					Rigidbody smallBirdRb = smallBird.GetComponent<Rigidbody>();

					smallBirdRb.AddForce(Vector3.forward * spawnForce, ForceMode.Impulse);
				}

				Destroy(this.gameObject);
			}
		}
	}
}
