using Raylib_cs;
using System.Numerics;

namespace RayLibTemplate
{
	//	Zombie!

	//128x128 tiles.  8 direction, 36 frames per direction.

	//Stance (4 frames)
	//Lurch(8 frames)
	//Slam(4 frames)
	//Bite(4 frames)
	//Block(2 frames)
	//Hit and Die(6 frames)
	//Critical Death(8 frames)


	//	Each frame of animation is 128x128px(large enough to fit all equipment). Animations are shown in 8 directions.

	//Stance(4 frames)
	//Running(8 frames)
	//Melee Swing(4 frames)
	//Block(2 frames)
	//Hit and Die(6 frames)
	//Cast Spell(4 frames)
	//Shoot Bow(4 frames)

	public class Player : Character, IUpdate, IDraw, IUnload
	{
		public override Vector2 Position { get; set; }
		public override PlayerState State { get; set; }
		public override Direction Direction { get; set; }
		public override int Speed { get; set; }

		public PlayerController PlayerConstroller { get; private set; }
		private EquipmentManager _equipmentManager = new EquipmentManager();

		public Player()
		{
			PlayerConstroller = new PlayerController(this);

			_equipmentManager.AddEquipment(new MaleHead(this));
			_equipmentManager.AddEquipment(new LongSword(this));
			_equipmentManager.AddEquipment(new LeatherArmor(this));

			Speed = 2;
			State = PlayerState.Stance;
		}

		public void Update()
		{
			PlayerConstroller.Input();
			_equipmentManager.Update();
		}

		public void Draw()
		{
			_equipmentManager.Draw();
		}

		public override Vector2 GetFrameOffSet()
		{
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

		public void Unload()
		{
			_equipmentManager.Unload();
		}
	}
}