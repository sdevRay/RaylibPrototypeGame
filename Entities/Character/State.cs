namespace RayLibTemplate.Entities.Character
{
	public class State
	{
		public Enum CurrentState { get; set; }

		public State(Enum initialState)
		{
			CurrentState = initialState;
		}
	}

}
