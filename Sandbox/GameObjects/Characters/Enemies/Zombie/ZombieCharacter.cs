using RayLibTemplate.Sandbox.GameObjects.Characters.Enemies.Zombie.States;
using System.Numerics;

namespace RayLibTemplate.Sandbox.GameObjects.Characters.Enemies.Zombie
{
	internal class ZombieCharacter : Character, IGameObject
	{
		public Vector2 Position { get; set; }

		public override AnimatedSprite AnimatedSprite { get; set; }

		public override StateContext StateContext { get; set; }

		public ZombieCharacter()
		{
			StateContext = new StateContext(new ZombieStateCriticalDeath());
			AnimatedSprite = new ZombieAnimatedSprite(this);
		}

		public void Draw()
		{
			AnimatedSprite.Animate(this);
		}

		public void Update()
		{
			StateContext.Request(this);
		}
	}
}
