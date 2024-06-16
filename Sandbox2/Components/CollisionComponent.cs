namespace RayLibTemplate.Sandbox2.Components
{
	internal class CollisionComponent : IComponent
	{
		public float Radius { get; set; }

		public CollisionComponent(float radius)
		{
			Radius = radius;
		}
	}
}
