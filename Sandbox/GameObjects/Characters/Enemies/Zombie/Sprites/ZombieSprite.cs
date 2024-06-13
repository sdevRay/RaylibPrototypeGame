using Raylib_cs;

namespace RayLibTemplate.Sandbox.GameObjects.Characters.Enemies.Zombie.Sprites
{
	internal class ZombieSprite : Sprite
	{
		public override Texture2D SpriteSheet => SpriteLoader.Enemy.Zombie;

		public override int RowCount => 8;

		public override int ColumnCount => 36;
	}
}
