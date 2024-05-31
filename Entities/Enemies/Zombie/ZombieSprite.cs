using RayLibTemplate.Entities.Character;
using RayLibTemplate.Entities.Character.Character;
using System.Numerics;

namespace RayLibTemplate.Entities.Enemies.Zombie
{
    //128x128 tiles.  8 direction, 36 frames per direction.

    //Stance (4 frames)
    //Lurch(8 frames)
    //Slam(4 frames)
    //Bite(4 frames)
    //Block(2 frames)
    //Hit and Die(6 frames)
    //Critical Death(8 frames)

    internal class ZombieSprite : ICharacterSprite
	{
		public AnimatedSpriteManager AnimatedSpriteManager { get; set; } = new AnimatedSpriteManager();
		public GameCharacter GameCharacter { get; set; }

		public ZombieSprite(GameCharacter gameCharacter)
		{
			var sprite = new AnimatedSprite(rowCount: 8, columnCount: 36, "Assets/Zombie/zombie_0.png", this);
			AnimatedSpriteManager.AddSprite(sprite);
			GameCharacter = gameCharacter;
		}

		public void Animate()
		{
			AnimatedSpriteManager.UpdateSprites();
			AnimatedSpriteManager.DrawSprites();
		}

		public void UnloadSprites()
		{
			AnimatedSpriteManager.UnloadSprites();
		}

		public Vector2 GetFrameOffSet()
		{
			int x = GameCharacter.State.CurrentState switch
			{
				ZombieStates.Stance => 0,
				ZombieStates.Lurch => 4,
				ZombieStates.Slam => 12,
				ZombieStates.Bite => 16,
				ZombieStates.Block => 18,
				ZombieStates.CriticalDeath => 18,
				_ => throw new NotImplementedException(),
			};

			int y = GameCharacter.Direction switch
			{
				Direction.Left => 0,
				Direction.UpLeft => 1,
				Direction.Up => 2,
				Direction.UpRight => 3,
				Direction.Right => 4,
				Direction.DownRight => 5,
				Direction.Down => 6,
				Direction.DownLeft => 7,
				_ => throw new NotImplementedException(),
			};

			return new Vector2(x, y);
		}

		public int GetFrameCount()
		{
			return GameCharacter.State.CurrentState switch
			{
				ZombieStates.Stance => 4,
				ZombieStates.Lurch => 8,
				ZombieStates.Slam => 4,
				ZombieStates.Bite => 4,
				ZombieStates.Block => 2,
				ZombieStates.HitAndDie => 6,
				ZombieStates.CriticalDeath => 8,
				_ => throw new NotImplementedException(),
			};
		}
	}
}
