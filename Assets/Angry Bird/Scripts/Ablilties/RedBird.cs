public class RedBird : Throwables
{
	/*private void Start()
	{
		Events.onTap += UseAblities;
	}

	private void OnDestroy()
	{
		Events.onTap -= UseAblities;
	}
*/
	public override void UseAblities()
	{
		if (!usedAbility)
		{
			usedAbility = true;
		}
			base.UseAblities();
	}
}
