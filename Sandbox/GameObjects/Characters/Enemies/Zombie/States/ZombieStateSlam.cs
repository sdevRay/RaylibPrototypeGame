namespace RayLibTemplate.Sandbox.GameObjects.Characters.Enemies.Zombie.States
{
	internal class ZombieStateSlam : State
	{
		public override float FrameOffSetX => 12;

		public override int FrameCount => 4;

		public ZombieStateSlam(Character character) : base(character, new SpriteAnimator(character))
		{
		}
	}
}
