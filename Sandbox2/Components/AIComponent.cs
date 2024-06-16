namespace RayLibTemplate.Sandbox2.Components
{
	internal class AIComponent : IComponent
	{
		public float AggroDistance { get; set; }

		public AIComponent(float aggroDistance)
		{
			AggroDistance = aggroDistance;
		}
	}
}

