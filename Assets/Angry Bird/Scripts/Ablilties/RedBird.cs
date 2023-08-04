public class RedBird : Throwables
{
	public override void UseAblities()
	{
		if (!usedAbility)
		{
			usedAbility = true;
		}
			base.UseAblities();
	}
}
