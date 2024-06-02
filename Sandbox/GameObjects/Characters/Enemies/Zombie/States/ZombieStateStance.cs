using RayLibTemplate.Entities.Characters;
using System.Numerics;

namespace RayLibTemplate.Sandbox.GameObjects.Characters.Enemies.Zombie.States
{
	internal class ZombieStateStance : IState
	{
		public Vector2 FrameOffSet => new Vector2(FrameOffSetX, StateUtility.GetFrameOffSetY(Direction));
		
		public float FrameOffSetX => 0;
		
		public Direction Direction { get; set; }
		
		public int FrameCount => 4;
		
		public void Handle(State state)
		{
			// TODO: Implement this method
		}
	}
}
