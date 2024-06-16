using Raylib_cs;

namespace RayLibTemplate.Sandbox2
{
	internal static class TextureLoader
	{
		private static readonly Dictionary<string, Texture2D> Textures = new Dictionary<string, Texture2D>();

		// Static constructor to load textures
		static TextureLoader()
		{
			LoadTexture("MaleHead1", "Assets/Player/male_head1.png");
			LoadTexture("Clothes", "Assets/Player/clothes.png");
			LoadTexture("LongSword", "Assets/Player/longsword.png");
			LoadTexture("Zombie", "Assets/Zombie/zombie_0.png");
			// Add more textures as needed
		}

		private static void LoadTexture(string name, string filePath)
		{
			Texture2D texture = Raylib.LoadTexture(filePath);
			Textures[name] = texture;
		}

		public static Texture2D GetTexture(string name)
		{
			if (Textures.TryGetValue(name, out Texture2D texture))
			{
				return texture;
			}
			else
			{
				throw new KeyNotFoundException($"Texture with name '{name}' not found.");
			}
		}

		public static void UnloadAllTextures()
		{
			foreach (var texture in Textures.Values)
			{
				Raylib.UnloadTexture(texture);
			}
			Textures.Clear();
		}
	}
}
