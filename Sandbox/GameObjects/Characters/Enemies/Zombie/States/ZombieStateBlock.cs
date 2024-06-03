using System.Numerics;

namespace RayLibTemplate.Sandbox.GameObjects.Characters.Enemies.Zombie.States
{
    // TODO: Reevaluate Frame OffSets and Frame Count
    // Finish scaffolding in Zombie States
    // Test State Handler to do some basic state changes

    // Add Player 

    // 
    internal class ZombieStateBlock : IState
	{
		public Vector2 FrameOffSet => new Vector2(FrameOffSetX, AnimatedSprite.GetFrameOffSetY(Direction));

		public Direction Direction { get; set; }

		public int FrameCount => 2;

		public float FrameOffSetX => 20;

		public void Handle(State state)
		{
		}
	}
}
