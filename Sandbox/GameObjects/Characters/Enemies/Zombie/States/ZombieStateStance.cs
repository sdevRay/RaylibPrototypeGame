namespace RayLibTemplate.Sandbox.GameObjects.Characters.Enemies.Zombie.States
{
	internal class ZombieStateStance : State
	{
		public override float FrameOffSetX => 0;

		public override int FrameCount => 4;

		public ZombieStateStance(Character character) : base(character, new PingPongSpriteAnimator(character))
		{
		}
	}
}
