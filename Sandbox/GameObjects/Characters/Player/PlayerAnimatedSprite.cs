using Raylib_cs;

namespace RayLibTemplate.Sandbox.GameObjects.Characters.Player
{
	//32-frame animation in 8 directions.

	//Stance(4 frames)
	//Running(8 frames) + 4
	//Melee Swing(4 frames) + 12
	//Block(2 frames) + 16
	//Hit and Die(6 frames) + 18
	//Cast Spell(4 frames) + 24
	//Shoot Bow(4 frames) + 28

	// TODO: Right now this is just set up for one Texture2D, but it needs expanded to handle head, armor, and weapon sprites.
	internal class PlayerAnimatedSprite : AnimatedSprite
	{
		protected override Texture2D SpriteSheet => SpriteLoader.Player.LeatherArmor;

		protected override int RowCount => 8;

		protected override int ColumnCount => 32;

		protected override float FrameTime => 0.1f;

		protected override int CurrentFrame { get; set; }

		protected override float Timer { get; set; }

		protected override Character Character { get; set; }

		public PlayerAnimatedSprite(Character character)
		{
			Character = (PlayerCharacter)character;
		}
	}
}
