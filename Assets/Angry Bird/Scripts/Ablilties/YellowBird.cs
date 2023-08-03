using UnityEngine;

public class YellowBird : Throwables
{
	public override void UseAblities()
	{
		base.UseAblities();
		if(!usedAbility)
		{
			if (_state == ThrowableState.Shooting)
			{
				rb.AddForce(Vector3.forward * 100f, ForceMode.Impulse);
				usedAbility = true;
			}
		}
	}
}
