namespace RayLibTemplate.Sandbox2.Components
{
	internal class MovementComponent : IComponent
	{
		public float Speed { get; set; }

		public MovementComponent(float speed)
		{
			Speed = speed;
		}
	}
}
