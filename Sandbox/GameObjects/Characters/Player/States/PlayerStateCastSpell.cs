using System.Numerics;

namespace RayLibTemplate.Sandbox.GameObjects.Characters.Player.States
{
	internal class PlayerStateCastSpell : IState
	{
		public float FrameOffSetX => 24;

		public Vector2 FrameOffSet => new Vector2(FrameOffSetX, AnimatedSprite.GetFrameOffSetY(Direction));

		public Direction Direction { get; set; }

		public int FrameCount => 4;

		public void Handle(State state)
		{
		}
	}
}
