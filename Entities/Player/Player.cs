using RayLibTemplate.Entities.Controllers;
using RayLibTemplate.Entities.Player.Equipment.Armor;
using RayLibTemplate.Entities.Player.Equipment.Heads;
using RayLibTemplate.Entities.Player.Equipment.Weapons;
using System.Numerics;

namespace RayLibTemplate.Entities.Player
{
    public class Player : Character<PlayerState>
	{
		public override Direction Direction { get; set; }
		public override int Speed { get; set; }
		public override Controller<PlayerState> Controller { get; set; }
		public override AnimatedSpriteManager<PlayerState> AnimatedSpriteManager { get; set; }
		public override PlayerState State { get; set; }

		public Player()
		{
			Controller = new PlayerController(this);

			AnimatedSpriteManager = new AnimatedSpriteManager<PlayerState>();
			AnimatedSpriteManager.AddSprite(new MaleHead(this));
			AnimatedSpriteManager.AddSprite(new LongSword(this));
			AnimatedSpriteManager.AddSprite(new LeatherArmor(this));

			Speed = 2;
			State = PlayerState.Stance;
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
			// TODO: Implement CastSpell and ShootBow states
			int x = State switch
			{
				PlayerState.Stance => 0,
				PlayerState.Running => 4,
				PlayerState.MeleeSwing => 12,
				PlayerState.Block => 16,
				PlayerState.HitAndDie => 18,
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
				PlayerState.Stance => 4,
				PlayerState.Running => 8,
				PlayerState.MeleeSwing => 4,
				PlayerState.Block => 2,
				PlayerState.HitAndDie => 6,
				PlayerState.CastSpell => 4,
				PlayerState.ShootBow => 4,
				_ => throw new NotImplementedException(),
			};
		}
	}
}