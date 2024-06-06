namespace RayLibTemplate.Sandbox.GameObjects.Characters
{
	public abstract class Character
	{
		public abstract IEnumerable<Sprite> Sprites { get; }
				
		public abstract Direction Direction { get; set; }
		
		public State CurrentState { get; set; }

		public void TransitionToState(State newState)
		{
			CurrentState = newState;
		}
	}
}
