using System.Numerics;

namespace RayLibTemplate.Sandbox.GameObjects.Characters.Enemies.Zombie.States
{
    internal class ZombieStateHitAndDie : IState
	{
		public Vector2 FrameOffSet => new Vector2(FrameOffSetX, AnimatedSprite.GetFrameOffSetY(Direction));

		public Direction Direction { get; set; }

		public int FrameCount => 6;

		public float FrameOffSetX => 22;

		public void Handle(State state)
		{

		}
	}
}
