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

		public Player()
		{
			SpriteSheet = Raylib.LoadTexture("Assets/Isometric_Hero/leather_armor.png");

			frameWidth = SpriteSheet.Width / 32; // zombie has 36 frames
			frameHeight = SpriteSheet.Height / 8; // Assuming 8 rows of frames
			origin = new Vector2(frameWidth / 2, frameHeight / 2);
			speed = 2;
			state = State.Stance;
		}

		public void Update()
		{
			timer += Raylib.GetFrameTime();

			if (timer >= frameTime)
			{
				timer = 0;
				currentFrame = (currentFrame + 1) % GetFrameCount(); // Loop through frames
			}

			Input();
		}

		void Input()
		{

			Vector2 movement = Vector2.Zero;

			if(movement == Vector2.Zero)
			{
				state = State.Stance;
			}

			if (Raylib.IsMouseButtonDown(MouseButton.Left))
			{
				state = State.MeleeSwing;
				return;
			}

			if (Raylib.IsMouseButtonDown(MouseButton.Right))
			{
				state = State.Block;
				return;
			}

			// TODO: For testing
			if(Raylib.IsKeyDown(KeyboardKey.Space))
			{
				state = State.HitAndDie;
				return;
			}

			if (Raylib.IsKeyDown(KeyboardKey.D))
			{
				movement.X += 1;
				direction = Direction.Right;
				state = State.Running;
			}
			if (Raylib.IsKeyDown(KeyboardKey.A))
			{
				movement.X -= 1;
				direction = Direction.Left;
				state = State.Running;
			}
			if (Raylib.IsKeyDown(KeyboardKey.W))
			{
				movement.Y -= 1;
				direction = Direction.Up;
				state = State.Running;
			}
			if (Raylib.IsKeyDown(KeyboardKey.S))
			{
				movement.Y += 1;
				direction = Direction.Down;
				state = State.Running;
			}

			if (Raylib.IsKeyDown(KeyboardKey.W) && Raylib.IsKeyDown(KeyboardKey.D))
			{
				direction = Direction.UpRight;
				state = State.Running;
			}

			if (Raylib.IsKeyDown(KeyboardKey.W) && Raylib.IsKeyDown(KeyboardKey.A))
			{
				direction = Direction.UpLeft;
				state = State.Running;
			}

			if (Raylib.IsKeyDown(KeyboardKey.S) && Raylib.IsKeyDown(KeyboardKey.D))
			{
				direction = Direction.DownRight;
				state = State.Running;
			}

			if (Raylib.IsKeyDown(KeyboardKey.S) && Raylib.IsKeyDown(KeyboardKey.A))
			{
				direction = Direction.DownLeft;
				state = State.Running;
			}


			// Normalize the movement vector and scale by the desired speed
			if (movement != Vector2.Zero)
			{
				movement = Vector2.Normalize(movement);
				Position += movement * speed; // Multiply by speed
			}
			//Debug.WriteLine($"Direction: {direction}");
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
			// Calculate the source rectangle for the current frame
			Rectangle sourceRec = new Rectangle((currentFrame + offset.X) * frameWidth, frameHeight * offset.Y, frameWidth, frameHeight);		
			Rectangle destRec = new Rectangle(Position.X, Position.Y, frameWidth, frameHeight);

			// Draw the character
			Raylib.DrawTexturePro(SpriteSheet, sourceRec, destRec, origin, 0, Color.White);
		}

		public void Unload()
		{
			Raylib.UnloadTexture(SpriteSheet);
		}

		int GetFrameCount()
		{
			// TODO: Maybe make these from state enum
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