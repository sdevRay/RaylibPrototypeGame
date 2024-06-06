using Raylib_cs;
using System.Numerics;

namespace RayLibTemplate.Sandbox.GameObjects.Characters
{
	public abstract class Sprite
	{
		public abstract Texture2D SpriteSheet { get; }

		public abstract int RowCount { get; }

		public abstract int ColumnCount { get; }

		public int FrameWidth => SpriteSheet.Width / ColumnCount;

		public int FrameHeight => SpriteSheet.Height / RowCount;

		public Vector2 Origin => new Vector2(FrameWidth / 2, FrameHeight / 2);
	}
}
