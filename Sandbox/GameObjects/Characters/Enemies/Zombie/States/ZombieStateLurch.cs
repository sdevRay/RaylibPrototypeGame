using System.Numerics;

namespace RayLibTemplate.Sandbox.GameObjects.Characters.Enemies.Zombie.States
{
	internal class ZombieStateLurch : State
	{
		public override Vector2 FrameOffSet => new Vector2(FrameOffSetX, AnimatedSprite.GetFrameOffSetY(_stateContext.Character.Direction));

		public override int FrameCount => 8;

		public override float FrameOffSetX => 4;

		public override void Handle()
		{
		}
	}
}
