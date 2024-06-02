using RayLibTemplate.Entities.Characters;
using System.Numerics;

namespace RayLibTemplate.Sandbox.GameObjects.Characters.Enemies.Zombie.States
{
	internal class ZombieStateLurch : IState
	{
		public Vector2 FrameOffSet => new Vector2(FrameOffSetX, StateUtility.GetFrameOffSetY(Direction));

		public Direction Direction { get; set; }

		public int FrameCount => 8;

		public float FrameOffSetX => 4;

		public void Handle(State state)
		{
		}
	}
}
