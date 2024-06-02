using RayLibTemplate.Sandbox.GameObjects.Characters.Enemies.Zombie.States;
using System.Diagnostics;
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
			Position = new Vector2(0, 0);
			State = new State(new ZombieStateBlock());
			AnimatedSprite = new ZombieAnimatedSprite(this);
			Speed = 1;
		}


		public void Destroy()
		{
		}

		public void Draw()
		{
			AnimatedSprite.Animate(this);

			Debug.WriteLine("Drawing ZombieCharacter");
		}

		public void Update()
		{
			State.Request();

			Debug.WriteLine("Updating ZombieCharacter");
		}
	}
}
