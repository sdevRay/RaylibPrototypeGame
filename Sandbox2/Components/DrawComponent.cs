using Raylib_cs;

namespace RayLibTemplate.Sandbox2.Components
{
    internal class DrawComponent : IComponent
	{
		public Texture2D Texture { get; set; }

		public DrawComponent(string fileName)
		{
			Texture = LoadSprite(fileName);
		}

		private static Texture2D LoadSprite(string fileName)
		{
			return Raylib.LoadTexture(fileName);
		}
	}
}
