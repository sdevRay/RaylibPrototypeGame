namespace RaylibPrototypeGame.Components
{
	internal class StateComponent : IComponent
    {
        public IState CurrentState { get; private set; }

        public StateComponent(IState initialState)
        {
            CurrentState = initialState;
        }

        public bool Equals(IState state)
        {
            return CurrentState.Equals(state);
        }

        public void ChangeState(IState newState)
        {
            CurrentState = newState;
        }
    }
}
