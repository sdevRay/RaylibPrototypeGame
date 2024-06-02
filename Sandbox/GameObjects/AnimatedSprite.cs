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
		protected abstract int FrameWidth { get; }
		protected abstract int FrameHeight { get; }
		protected abstract Vector2 Origin { get; }
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
				CurrentFrame = (CurrentFrame + 1) % Character.State.CurrentState.FrameCount; // Loop through frames
			}
		}
		protected void DrawSprite(IGameObject gameObject)
		{
			Rectangle sourceRec = new((CurrentFrame + Character.State.CurrentState.FrameOffSet.X) * FrameWidth, FrameHeight * Character.State.CurrentState.FrameOffSet.Y, FrameWidth, FrameHeight);

			Rectangle destRec = new(gameObject.Position.X, gameObject.Position.Y, FrameWidth, FrameHeight);
			Raylib.DrawTexturePro(SpriteSheet, sourceRec, destRec, Origin, 0, Color.White);
		}
	}
}
