using System.Numerics;

namespace RayLibTemplate.Sandbox.GameObjects.Characters.Enemies.Zombie.States
{
	internal class ZombieStateBlock : State
	{
		public override Vector2 FrameOffSet => new Vector2(FrameOffSetX, AnimatedSprite.GetFrameOffSetY(Direction));

		public override Direction Direction { get; set; }

		public override int FrameCount => 2;

		public override float FrameOffSetX => 20;

		public override void Handle(IGameObject gameObject)
		{
		}
	}
}
