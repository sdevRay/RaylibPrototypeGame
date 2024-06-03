using System.Numerics;

namespace RayLibTemplate.Sandbox.GameObjects.Characters
{
	abstract class State
    {
		protected StateContext _stateContext;
		public abstract float FrameOffSetX { get; }
		public abstract Vector2 FrameOffSet { get; }
		public abstract Direction Direction { get; set; }
		public abstract int FrameCount { get; }

		public void SetContext(StateContext context)
		{
			_stateContext = context;
		}

		public abstract void Handle(IGameObject gameObject);
	}
}
