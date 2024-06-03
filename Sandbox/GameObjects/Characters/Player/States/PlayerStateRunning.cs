using System.Numerics;

namespace RayLibTemplate.Sandbox.GameObjects.Characters.Player.States
{
	internal class PlayerStateRunning : IState
	{
		public float FrameOffSetX => 4;

		public Vector2 FrameOffSet => new Vector2(FrameOffSetX, AnimatedSprite.GetFrameOffSetY(Direction));

		public Direction Direction { get; set; }

		public int FrameCount => 8;

		public void Handle(State state)
		{
		}
	}
}
