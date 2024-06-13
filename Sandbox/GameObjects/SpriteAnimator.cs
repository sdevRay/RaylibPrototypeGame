using Raylib_cs;
using RayLibTemplate.Sandbox.GameObjects.Characters;

namespace RayLibTemplate.Sandbox.GameObjects
{
	public class SpriteAnimator
	{
		protected float _frameTime { get; } = 0.1f; // Time per frame

		protected float _timer;

		protected float _currentFrame;

		public Character Character { get; set; }

		public SpriteAnimator(Character character)
		{
			Character = character;
		}

		public virtual void Update()
		{
			_timer += Raylib.GetFrameTime();

			if (_timer >= _frameTime)
			{
				_timer = 0;
				_currentFrame = (_currentFrame + 1) % Character.CurrentState.FrameCount; // Loop through frames
			}
		}

		public void Draw()
		{
			foreach(var sprite in Character.Sprites)
			{
				Rectangle sourceRec = new((_currentFrame + Character.CurrentState.FrameOffSet.X) * sprite.FrameWidth, sprite.FrameHeight * Character.CurrentState.FrameOffSet.Y, sprite.FrameWidth, sprite.FrameHeight);

				Rectangle destRec = new(((IGameObject)Character).Position.X, ((IGameObject)Character).Position.Y, sprite.FrameWidth, sprite.FrameHeight);
				Raylib.DrawTexturePro(sprite.SpriteSheet, sourceRec, destRec, sprite.Origin, 0, Color.White);
			}		
		}

		public static int GetFrameOffSetY(Direction direction)
		{
			return direction switch
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
		}
	}
}
