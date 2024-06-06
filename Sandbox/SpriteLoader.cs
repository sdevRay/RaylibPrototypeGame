using Raylib_cs;

namespace RayLibTemplate.Sandbox
{
	public static class SpriteLoader
	{
		public static class Player
		{
			public static Texture2D LeatherArmor { get; private set; }
			public static Texture2D MaleHeadOne { get; private set; }
			public static Texture2D LongSword { get; private set; }

			static Player()
			{
				LeatherArmor = LoadSprite("Assets/Player/leather_armor.png");
				MaleHeadOne = LoadSprite("Assets/Player/male_head1.png");
				LongSword = LoadSprite("Assets/Player/longsword.png");
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
			// Enemy
			Raylib.UnloadTexture(Enemy.Zombie);

			// Player
			Raylib.UnloadTexture(Player.LeatherArmor);
			Raylib.UnloadTexture(Player.MaleHeadOne);
			Raylib.UnloadTexture(Player.LongSword);
		}
	}
}
