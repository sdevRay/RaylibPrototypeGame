using RayLibTemplate.Sandbox.GameObjects.Characters.Enemies.Zombie.States;
using System.Numerics;

namespace RayLibTemplate.Sandbox.GameObjects.Characters.Enemies.Zombie
{
	internal class ZombieCharacter : Character, IGameObject
	{
		public Vector2 Position { get; set; }

		public override AnimatedSprite AnimatedSprite { get; set; }

		public override State State { get; set; }

		public override int Speed { get; set; }

		public ZombieCharacter()
		{
			State = new State(new ZombieStateCriticalDeath());
			AnimatedSprite = new ZombieAnimatedSprite(this);
			Speed = 1;
		}

		public void Draw()
		{
			AnimatedSprite.Animate(this);
		}

		public void Update()
		{
			State.Request();
		}
	}
}
