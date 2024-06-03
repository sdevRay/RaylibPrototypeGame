using Raylib_cs;
using RayLibTemplate.Sandbox.GameObjects.Characters;
using System.Numerics;

namespace RayLibTemplate.Sandbox.GameObjects
{
	abstract class AnimatedSprite
	{
		protected abstract Texture2D SpriteSheet { get; }

		protected abstract int RowCount { get; }

		protected abstract int ColumnCount { get; }

		public int FrameWidth => SpriteSheet.Width / ColumnCount;

		public int FrameHeight => SpriteSheet.Height / RowCount;

		public Vector2 Origin => new Vector2(FrameWidth / 2, FrameHeight / 2);

		protected abstract float FrameTime { get; } // Time per frame

		protected abstract int CurrentFrame { get; set; }

		protected abstract float Timer { get; set; }

		protected abstract Character Character { get; set; }

		public void Animate(IGameObject gameObject)
		{
			UpdateSprite();
			DrawSprite(gameObject);
		}

		protected void UpdateSprite()
		{
			Timer += Raylib.GetFrameTime();

			if (Timer >= FrameTime)
			{
				Timer = 0;
				CurrentFrame = (CurrentFrame + 1) % Character.StateContext.CurrentState.FrameCount; // Loop through frames
			}
		}
		
		protected void DrawSprite(IGameObject gameObject)
		{
			Rectangle sourceRec = new((CurrentFrame + Character.StateContext.CurrentState.FrameOffSet.X) * FrameWidth, FrameHeight * Character.StateContext.CurrentState.FrameOffSet.Y, FrameWidth, FrameHeight);

			Rectangle destRec = new(gameObject.Position.X, gameObject.Position.Y, FrameWidth, FrameHeight);
			Raylib.DrawTexturePro(SpriteSheet, sourceRec, destRec, Origin, 0, Color.White);
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
