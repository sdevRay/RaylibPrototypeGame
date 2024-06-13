namespace RayLibTemplate.Sandbox2.Components
{
	internal class StateComponent<T> : IComponent where T : Enum
	{
		public T CurrentState { get; private set; }

		public StateComponent(T initialState)
		{
			CurrentState = initialState;
		}

		public void ChangeState(T newState)
		{
			CurrentState = newState;
			Console.WriteLine($"State changed to: {newState}");
		}
	}
}
