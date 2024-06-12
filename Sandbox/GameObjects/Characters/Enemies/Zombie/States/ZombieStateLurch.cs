using System.Numerics;

namespace RayLibTemplate.Sandbox.GameObjects.Characters.Enemies.Zombie.States
{
	internal class ZombieStateLurch : State
	{
		public override float FrameOffSetX => 4;

		public override int FrameCount => 8;

		public ZombieStateLurch(Character character) : base(character, new SpriteAnimator(character))
		{
		}
	}
}
