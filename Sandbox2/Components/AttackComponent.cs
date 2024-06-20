namespace RayLibTemplate.Sandbox2.Components
{
	internal class AttackComponent : IComponent
	{
		public float Damage { get; set; }
		public float AttackRange { get; set; }
		public float Cooldown { get; set; }
		public float CurrentCooldown { get; set; }
	}
}
