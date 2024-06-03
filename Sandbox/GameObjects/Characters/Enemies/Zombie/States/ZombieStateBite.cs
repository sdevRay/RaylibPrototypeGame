using System.Numerics;

namespace RayLibTemplate.Sandbox.GameObjects.Characters.Enemies.Zombie.States
{
    internal class ZombieStateBite : IState
	{
		public Vector2 FrameOffSet => new Vector2(FrameOffSetX, AnimatedSprite.GetFrameOffSetY(Direction));

		public Direction Direction { get; set; }

		public int FrameCount => 4;

		public float FrameOffSetX => 16;

		public void Handle(State state)
		{

		}
	}
}
