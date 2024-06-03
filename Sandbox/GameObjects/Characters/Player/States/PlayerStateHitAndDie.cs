using System.Numerics;

namespace RayLibTemplate.Sandbox.GameObjects.Characters.Player.States
{
	internal class PlayerStateHitAndDie : IState
	{
		public float FrameOffSetX => 18;

		public Vector2 FrameOffSet => new Vector2(FrameOffSetX, AnimatedSprite.GetFrameOffSetY(Direction));

		public Direction Direction { get; set; }

		public int FrameCount => 6;

		public void Handle(State state)
		{
		}
	}
}
