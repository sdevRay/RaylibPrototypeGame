using Raylib_cs;

namespace RayLibTemplate
{
	// TODO: Implement a TextureManager class that loads and unloads textures
	// Also may have static references to all loaded textures
	// Right now the sprite classes handles this responsibility 
	static class TextureManager
	{
		private static readonly Dictionary<string, Texture2D> textures = [];

		static TextureManager()
		{
			LoadTexture("Assets/Zombie/Zombie_0.png");
		}

		public static Texture2D LoadTexture(string path)
		{
			if (textures.TryGetValue(path, out Texture2D value))
			{
				return value;
			}
			else
			{
				Texture2D texture = Raylib.LoadTexture(path);
				textures.Add(path, texture);
				return texture;
			}
		}

		public static void UnloadTexture(string path)
		{
			if (textures.TryGetValue(path, out Texture2D value))
			{
				Raylib.UnloadTexture(value);
				textures.Remove(path);
			}
		}

		public static void UnloadAllTextures()
		{
			foreach (var texture in textures.Values)
			{
				Raylib.UnloadTexture(texture);
			}

			textures.Clear();
		}
	}
}
