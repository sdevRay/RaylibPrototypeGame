using System.Numerics;

namespace RayLibTemplate.Sandbox.GameObjects.Characters.Player.States
{
	internal class PlayerStateBlock : IState
	{
		public float FrameOffSetX => 16;

		public Vector2 FrameOffSet => new Vector2(FrameOffSetX, AnimatedSprite.GetFrameOffSetY(Direction));

		public Direction Direction { get; set; } = Direction.Right;

		public int FrameCount => 2;

		public void Handle(State state)
		{
		}
	}
}
