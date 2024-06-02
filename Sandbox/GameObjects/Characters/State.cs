namespace RayLibTemplate.Sandbox.GameObjects.Characters
{
	public class State
    {
		private IState _state;

		public State(IState state)
		{
			_state = state;
		}

		public IState CurrentState
		{
			get { return _state; }
			set
			{
				_state = value;
				Console.WriteLine("State changed to " + _state.GetType().Name);
			}
		}

		public void Request()
		{
			_state.Handle(this);
		}
	}
}
