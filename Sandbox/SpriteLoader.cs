using Raylib_cs;

namespace RayLibTemplate.Sandbox
{
	public static class SpriteLoader
	{

		public static class Player
		{
			public static Texture2D LeatherArmor { get; private set; }

			static Player()
			{
				LeatherArmor = LoadSprite("Assets/Player/leather_armor.png");
			}
		}

		public static class Enemy
		{
			public static Texture2D Zombie { get; private set; }

			static Enemy()
			{
				Zombie = LoadSprite("Assets/Zombie/zombie_0.png");
			}
		}

		private static Texture2D LoadSprite(string fileName)
		{
			return Raylib.LoadTexture(fileName);
		}

		public static void UnloadSprites()
		{
			Raylib.UnloadTexture(Enemy.Zombie);
		}
	}
}
