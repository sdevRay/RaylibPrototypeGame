using Raylib_cs;
using System.Numerics;

namespace RayLibTemplate.Sandbox.GameObjects.Characters.Enemies.Zombie
{
	//128x128 tiles.  8 direction, 36 frames per direction.

	//Stance (4 frames)
	//Lurch(8 frames)
	//Slam(4 frames)
	//Bite(4 frames)
	//Block(2 frames)
	//Hit and Die(6 frames)
	//Critical Death(8 frames)

	internal class ZombieAnimatedSprite : AnimatedSprite
	{
		protected override Texture2D SpriteSheet => SpriteLoader.Enemy.Zombie;

		protected override int RowCount => 8;

		protected override int ColumnCount => 36;

		protected override int FrameWidth => SpriteSheet.Width / ColumnCount;

		protected override int FrameHeight => SpriteSheet.Height / RowCount;

		protected override Vector2 Origin => new Vector2(FrameWidth / 2, FrameHeight / 2);

		protected override float FrameTime => 0.1f;

		protected override int CurrentFrame { get; set; }

		protected override float Timer { get; set; }

		protected override Character Character { get; set; }

        public ZombieAnimatedSprite(Character character)
		{
			Character = (ZombieCharacter)character;
		}
	}
}
