using RayLibTemplate.Sandbox2.Enums;

namespace RayLibTemplate.Sandbox2.Components
{
    internal class FrameState
	{
		public int FrameOffSetX { get; }

		public int FrameCount { get; }

		public AnimationType AnimationType { get; }

        public FrameState(int frameCount, int frameOffSetX, AnimationType animationType)
        {
			FrameCount = frameCount;
			FrameOffSetX = frameOffSetX;
			AnimationType = animationType;
		}
    }

	internal class FrameComponent : IComponent
	{
		public Dictionary<IState, FrameState> FrameByState { get; set; }

		public Direction Direction { get; set; }

		public float FrameTime { get; } = 0.1f; // Time per frame

		public float Timer { get; set; }

		public float CurrentFrame { get; set; }

		public bool IsPlayingForward { get; set; }

		public FrameComponent()
        {
			FrameByState = new Dictionary<IState, FrameState>();
        }

		public void AddFrameState(IState state, FrameState frameState)
		{
			if (!FrameByState.ContainsKey(state))
			{
				FrameByState[state] = frameState;
			}
		}

		public FrameState GetFrameForState(IState state)
		{
			if (FrameByState.TryGetValue(state, out FrameState? value))
			{
				return value;
			}
			else
			{
				throw new KeyNotFoundException($"No FrameState found for PlayerState: {state}");
			}
		}

		public int FrameOffSetY 
		{ 
			get 
			{
				return Direction switch
				{
					Direction.Left => 0,
					Direction.UpLeft => 1,
					Direction.Up => 2,
					Direction.UpRight => 3,
					Direction.Right => 4,
					Direction.DownRight => 5,
					Direction.Down => 6,
					Direction.DownLeft => 7,
					_ => throw new InvalidOperationException($"Unhandled direction: {Direction}")
				};
			} 
		}
	}
}
