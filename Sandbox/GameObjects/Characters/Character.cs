using RayLibTemplate.Sandbox2.Enums;

namespace RayLibTemplate.Sandbox.GameObjects.Characters
{
    public abstract class Character
	{
		public abstract IEnumerable<Sprite> Sprites { get; }
				
		public Direction Direction { get; set; }
		
		public State CurrentState { get; set; }

		public float CollisionRadius { get; set; }

		public float AttackRange { get; set; }

		public float Health { get; set; }

		public void TransitionToState(State newState)
		{
			CurrentState = newState;
		}
	}
}
