using RayLibTemplate.Entities.Characters;
using System.Numerics;

namespace RayLibTemplate.Sandbox.GameObjects.Characters
{
	public interface IState
	{
		float FrameOffSetX { get; }
		Vector2 FrameOffSet { get; }
		Direction Direction { get; set; }
		int FrameCount { get; }
		void Handle(State state);
	}
}
