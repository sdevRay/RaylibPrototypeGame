using RayLibTemplate.Entities.Controllers;
using System.Numerics;

namespace RayLibTemplate.Entities.Enemies.Zombie
{
	internal class Zombie : Character<ZombieState>
	{
		public override Direction Direction { get; set; }
		public override int Speed { get; set; }
		public override Controller<ZombieState> Controller { get; set; }
		public override AnimatedSpriteManager<ZombieState> AnimatedSpriteManager { get; set; }
		public override ZombieState State { get; set; }

		public Zombie()
		{
			Controller = new ZombieController(this);

			AnimatedSpriteManager = new AnimatedSpriteManager<ZombieState>();
			AnimatedSpriteManager.AddSprite(new ZombieSprite(this));
			State = ZombieState.Stance;

			// TODO: For testing
			Position = new Vector2(250, 250);
		}

		public override void Update()
		{
			Controller.Input();
			AnimatedSpriteManager.Update();
		}

		public override void Draw()
		{
			AnimatedSpriteManager.Draw();
		}

		public override void Unload()
		{
			AnimatedSpriteManager.Unload();
		}

		public override Vector2 GetFrameOffSet()
		{
			int x = State switch
			{
				ZombieState.Stance => 0,
				ZombieState.Lurch => 4,
				ZombieState.Slam => 12,
				ZombieState.Bite => 16,
				ZombieState.Block => 18,
				ZombieState.CriticalDeath => 18,
				_ => throw new NotImplementedException(),
			};

			int y = Direction switch
			{
				Direction.Left => 0,
				Direction.UpLeft => 1,
				Direction.Up => 2,
				Direction.UpRight => 3,
				Direction.Right => 4,
				Direction.DownRight => 5,
				Direction.Down => 6,
				Direction.DownLeft => 7,
				_ => throw new NotImplementedException(),
			};

			return new Vector2(x, y);
		}

		public override int GetFrameCount()
		{
			return State switch
			{
				ZombieState.Stance => 4,
				ZombieState.Lurch => 8,
				ZombieState.Slam => 4,
				ZombieState.Bite => 4,
				ZombieState.Block => 2,
				ZombieState.HitAndDie => 6,
				ZombieState.CriticalDeath => 8,
				_ => throw new NotImplementedException(),
			};
		}
	}
}