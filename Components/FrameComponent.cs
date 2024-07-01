using RayLibTemplate.Enums;

namespace RayLibTemplate.Components
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

        public float FrameTime { get; } = 0.1f; // Time per frame

        public float Timer { get; set; }

        public float CurrentFrame { get; set; }

        public bool IsPlayingForward { get; set; }

        public bool HasCompletedPingPong { get; set; }

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
    }
}
