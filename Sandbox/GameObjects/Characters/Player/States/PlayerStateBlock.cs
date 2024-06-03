using System.Numerics;

namespace RayLibTemplate.Sandbox.GameObjects.Characters.Player.States
{
	internal class PlayerStateBlock : State
	{
		public override float FrameOffSetX => 16;

		public override Vector2 FrameOffSet => new Vector2(FrameOffSetX, AnimatedSprite.GetFrameOffSetY(Direction));

		public override Direction Direction { get; set; } = Direction.Right;

		public override int FrameCount => 2;

		public override void Handle(IGameObject gameObject)
		{
		}
	}
}
