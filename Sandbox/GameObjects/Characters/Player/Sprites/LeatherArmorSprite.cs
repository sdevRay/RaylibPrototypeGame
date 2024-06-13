using Raylib_cs;

namespace RayLibTemplate.Sandbox.GameObjects.Characters.Player.Sprites
{
	internal class LeatherArmorSprite : Sprite
	{
		public override Texture2D SpriteSheet => SpriteLoader.Player.LeatherArmor;

		public override int RowCount => 8;

		public override int ColumnCount => 32;
	}
}
