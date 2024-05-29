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

	enum State
	{
		Stance,
		Running,
		MeleeSwing,
		Block,
		HitAndDie,
		CastSpell,
		ShootBow
	}

	enum Direction
	{
		Up,
		Down,
		Left,
		Right,
		UpLeft,
		UpRight,
		DownLeft,
		DownRight
	}

	public class Player
	{
		public Texture2D SpriteSheet { get; private set; }
		public Vector2 Position;
		private State state;
		private Direction direction;

		// Sprite sheet details
		readonly int frameWidth;
		readonly int frameHeight;
		readonly float frameTime = 0.1f; // Time per frame
		int currentFrame = 0;
		float timer = 0;
		Vector2 origin;
		int speed = 1;

		// Sword
		public Texture2D Weapon { get; private set; }
		readonly int frameWidth1;
		readonly int frameHeight1;
		Vector2 origin1;

		// Head
		public Texture2D Head { get; private set; }
		readonly int frameWidth2;
		readonly int frameHeight2;
		Vector2 origin2;

		readonly List<(List<KeyboardKey> Keys, Direction Direction, State State)> _keyMappings = 
			[
			(new List<KeyboardKey> { KeyboardKey.D }, Direction.Right, State.Running),
			(new List<KeyboardKey> { KeyboardKey.A }, Direction.Left, State.Running),
			(new List<KeyboardKey> { KeyboardKey.W }, Direction.Up, State.Running),
			(new List<KeyboardKey> { KeyboardKey.S }, Direction.Down, State.Running),
			(new List<KeyboardKey> { KeyboardKey.W, KeyboardKey.D }, Direction.UpRight, State.Running),
			(new List<KeyboardKey> { KeyboardKey.W, KeyboardKey.A }, Direction.UpLeft, State.Running),
			(new List<KeyboardKey> { KeyboardKey.S, KeyboardKey.D }, Direction.DownRight, State.Running),
			(new List<KeyboardKey> { KeyboardKey.S, KeyboardKey.A }, Direction.DownLeft, State.Running),
		];

		public Player()
		{
			// Head
			Head = Raylib.LoadTexture("Assets/Isometric_Hero/male_head2.png");
			frameWidth2 = Head.Width / 32;
			frameHeight2 = Head.Height / 8; // 8 rows of frames
			origin2 = new Vector2(frameWidth2 / 2, frameHeight2 / 2);

			// Sword
			Weapon = Raylib.LoadTexture("Assets/Isometric_Hero/longsword.png");
			frameWidth1 = Weapon.Width / 32;
			frameHeight1 = Weapon.Height / 8; // 8 rows of frames
			origin1 = new Vector2(frameWidth1 / 2, frameHeight1 / 2);

			// Player
			SpriteSheet = Raylib.LoadTexture("Assets/Isometric_Hero/leather_armor.png");
			frameWidth = SpriteSheet.Width / 32;
			frameHeight = SpriteSheet.Height / 8; // 8 rows of frames
			origin = new Vector2(frameWidth / 2, frameHeight / 2);
			speed = 2;
			state = State.Stance;
		}

		public void Update()
		{
			UpdateFrames();
			Input();
		}

		void UpdateFrames()
		{
			timer += Raylib.GetFrameTime();

			if (timer >= frameTime)
			{
				timer = 0;
				currentFrame = (currentFrame + 1) % GetFrameCount(); // Loop through frames
			}
		}

		void Input()
		{
			Vector2 movement = Vector2.Zero;
			state = State.Stance;

			if (Raylib.IsMouseButtonDown(MouseButton.Left))
			{
				state = State.MeleeSwing;
			}
			else if (Raylib.IsMouseButtonDown(MouseButton.Right))
			{
				state = State.Block;
			}

			//// TODO: For testing
			//if(Raylib.IsKeyDown(KeyboardKey.Space))
			//{
			//	state = State.HitAndDie;
			//	return;
			//}

			foreach (var mapping in _keyMappings)
			{
				if (mapping.Keys.All(key => Raylib.IsKeyDown(key)))
				{
					movement += mapping.Direction switch
					{
						Direction.Right => new Vector2(1, 0),
						Direction.Left => new Vector2(-1, 0),
						Direction.Up => new Vector2(0, -1),
						Direction.Down => new Vector2(0, 1),
						Direction.UpRight => new Vector2(1, -1),
						Direction.UpLeft => new Vector2(-1, -1),
						Direction.DownRight => new Vector2(1, 1),
						Direction.DownLeft => new Vector2(-1, 1),
						_ => Vector2.Zero,
					};
					direction = mapping.Direction;
					state = mapping.State;
				}
			}

			if (movement != Vector2.Zero)
			{
				movement = Vector2.Normalize(movement);
				Position += movement * speed;
			}
		}

		Vector2 GetFrameOffSet()
		{
			int x = state switch
			{
				State.Stance => 0,
				State.Running => 4,
				State.MeleeSwing => 12,
				State.Block => 16,
				State.HitAndDie => 18,
				_ => throw new NotImplementedException(),
			};

			int y = direction switch
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


		public void Draw()
		{
			var offset = GetFrameOffSet();

			// Draw the head
			Rectangle sourceRec2 = new Rectangle((currentFrame + offset.X) * frameWidth2, frameHeight2 * offset.Y, frameWidth2, frameHeight2);
			Rectangle destRec2 = new Rectangle(Position.X, Position.Y, frameWidth2, frameHeight2);
			Raylib.DrawTexturePro(Head, sourceRec2, destRec2, origin2, 0, Color.White);


			// Calculate the source rectangle for the current frame
			// Draw the character
			Rectangle sourceRec = new Rectangle((currentFrame + offset.X) * frameWidth, frameHeight * offset.Y, frameWidth, frameHeight);
			Rectangle destRec = new Rectangle(Position.X, Position.Y, frameWidth, frameHeight);
			Raylib.DrawTexturePro(SpriteSheet, sourceRec, destRec, origin, 0, Color.White);


			// Draw the sword
			Rectangle sourceRec1 = new Rectangle((currentFrame + offset.X) * frameWidth1, frameHeight1 * offset.Y, frameWidth1, frameHeight1);
			Rectangle destRec1 = new Rectangle(Position.X, Position.Y, frameWidth1, frameHeight1);
			Raylib.DrawTexturePro(Weapon, sourceRec1, destRec1, origin1, 0, Color.White);


		}

		public void Unload()
		{
			Raylib.UnloadTexture(SpriteSheet);
		}

		int GetFrameCount()
		{
			return state switch
			{
				State.Stance => 4,
				State.Running => 8,
				State.MeleeSwing => 4,
				State.Block => 2,
				State.HitAndDie => 6,
				State.CastSpell => 4,
				State.ShootBow => 4,
				_ => throw new NotImplementedException(),
			};
		}
	}
}