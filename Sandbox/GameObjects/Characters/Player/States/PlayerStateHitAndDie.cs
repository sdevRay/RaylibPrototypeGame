using System.Numerics;

namespace RayLibTemplate.Sandbox.GameObjects.Characters.Player.States
{
	internal class PlayerStateHitAndDie : State
	{
		public override float FrameOffSetX => 18;

		public override Vector2 FrameOffSet => new Vector2(FrameOffSetX, AnimatedSprite.GetFrameOffSetY(Direction));

		public override Direction Direction { get; set; }

		public override int FrameCount => 6;

		public override void Handle(IGameObject gameObject)
		{
		}
	}
}
