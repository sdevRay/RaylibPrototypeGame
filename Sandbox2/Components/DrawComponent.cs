using Raylib_cs;
using System.Numerics;

namespace RayLibTemplate.Sandbox2.Components
{
	internal class Sprite
	{
		public Texture2D Texture { get; set; }

		public string Name { get; set; }

		public int FrameWidth { get; }

		public int FrameHeight { get; }

		public Vector2 Origin => new Vector2(FrameWidth / 2, FrameHeight / 2);

        public Sprite(string spriteName, int columnCount, int rowCount)
        {
			Texture = TextureLoader.GetTexture(spriteName);
			Name = spriteName;

			FrameWidth = Texture.Width / columnCount;
			FrameHeight = Texture.Height / rowCount;
		}
	}

	internal class DrawComponent : IComponent
	{
		public List<Sprite> Sprites { get; set; }

		public int RowCount { get; }

		public int ColumnCount { get; }

		public DrawComponent(int rowCount, int columnCount)
		{
			Sprites = new List<Sprite>();

			RowCount = rowCount;
			ColumnCount = columnCount;
		}

		public void AddSprite(string spriteName)
		{
			var sprite = new Sprite(spriteName, ColumnCount, RowCount);
			Sprites.Add(sprite);
		}
	}
}
