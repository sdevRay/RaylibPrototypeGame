namespace RayLibTemplate.Sandbox2.Components
{
	internal class PlayerMovementComponent : IComponent
	{
		public float Speed { get; set; }

		public PlayerMovementComponent(float speed)
		{
			Speed = speed;
		}
	}
}
