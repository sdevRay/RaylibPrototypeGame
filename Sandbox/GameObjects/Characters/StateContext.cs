namespace RayLibTemplate.Sandbox.GameObjects.Characters
{
	class StateContext
	{
		private State _state;

		public State CurrentState => _state;

		public StateContext(State state)
		{
			TransitionTo(state);
		}

		public void TransitionTo(State state)
		{
			_state = state;
			_state.SetContext(this);

			Console.WriteLine($"Context: Transition to {state.GetType().Name}.");
		}

		public void Request(IGameObject gameObject)
		{
			_state.Handle(gameObject);
		}
	}
}
