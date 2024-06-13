using System.Numerics;

namespace RayLibTemplate.Sandbox.GameObjects.Characters.Enemies.Zombie.States
{
	internal class ZombieStateBite : State
	{
		public override Vector2 FrameOffSet => new Vector2(FrameOffSetX, AnimatedSprite.GetFrameOffSetY(_stateContext.Character.Direction));

		public override int FrameCount => 4;

		public override float FrameOffSetX => 16;

		public override void Handle()
		{
		}
	}
}
