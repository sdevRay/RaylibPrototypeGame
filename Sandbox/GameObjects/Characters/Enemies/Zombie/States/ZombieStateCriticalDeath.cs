using System.Numerics;

namespace RayLibTemplate.Sandbox.GameObjects.Characters.Enemies.Zombie.States
{
    internal class ZombieStateCriticalDeath : IState
	{
		public Vector2 FrameOffSet => new Vector2(FrameOffSetX, AnimatedSprite.GetFrameOffSetY(Direction));

		public Direction Direction { get; set; }

		public int FrameCount => 8;

		public float FrameOffSetX => 28;

		public void Handle(State state)
		{
		}
	}
}