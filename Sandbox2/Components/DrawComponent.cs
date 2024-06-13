using Raylib_cs;
using System.Numerics;

namespace RayLibTemplate.Sandbox2.Components
{
	internal class Sprite
	{

	}

	internal class DrawComponent : IComponent
	{
		public Texture2D Texture { get; set; }

		public int RowCount { get; }

		public int ColumnCount { get; }

		public int FrameWidth => Texture.Width / ColumnCount;

		public int FrameHeight => Texture.Height / RowCount;

		public Vector2 Origin => new Vector2(FrameWidth / 2, FrameHeight / 2);

		public DrawComponent(string fileName, int rowCount, int columnCount)
		{
			Texture = LoadSprite(fileName);
			RowCount = rowCount;
			ColumnCount = columnCount;
		}

		private static Texture2D LoadSprite(string fileName)
		{
			return Raylib.LoadTexture(fileName);
		}
	}
}
