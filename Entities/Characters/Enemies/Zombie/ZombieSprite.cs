//using System.Numerics;

//namespace RayLibTemplate.Entities.Characters.Enemies.Zombie
//{
//	//128x128 tiles.  8 direction, 36 frames per direction.

//	//Stance (4 frames)
//	//Lurch(8 frames)
//	//Slam(4 frames)
//	//Bite(4 frames)
//	//Block(2 frames)
//	//Hit and Die(6 frames)
//	//Critical Death(8 frames)

//	internal class ZombieSprite : ICharacterSprite
//	{
//		public AnimatedSpriteManager AnimatedSpriteManager { get; set; } = new AnimatedSpriteManager();
//		public GameCharacter GameCharacter { get; set; }

//		public ZombieSprite(GameCharacter gameCharacter)
//		{
//			var sprite = new AnimatedSprite(rowCount: 8, columnCount: 36, "Assets/Zombie/zombie_0.png", this);
//			AnimatedSpriteManager.AddSprite(sprite);
//			GameCharacter = gameCharacter;
//		}

//		public void Animate()
//		{
//			AnimatedSpriteManager.UpdateSprites();
//			AnimatedSpriteManager.DrawSprites();
//		}

//		public void UnloadSprites()
//		{
//			AnimatedSpriteManager.UnloadSprites();
//		}

//		public Vector2 GetFrameOffSet()
//		{
//			int x = (GameCharacter.State.CurrentState as ZombieState)?.CurrentState switch
//			{
//				ZombieStates.Stance => 0,
//				ZombieStates.Lurch => 4,
//				ZombieStates.Slam => 12, +8
//				ZombieStates.Bite => 16, +4
//				ZombieStates.Block => 20, +4
//				ZombieStates.HitAndDie => 22, +2
//				ZombieStates.CriticalDeath => 28, +6
//				
//				_ => throw new NotImplementedException(),
//			};

//			int y = GameCharacter.Direction switch
//			{
//				Direction.Left => 0,
//				Direction.UpLeft => 1,
//				Direction.Up => 2,
//				Direction.UpRight => 3,
//				Direction.Right => 4,
//				Direction.DownRight => 5,
//				Direction.Down => 6,
//				Direction.DownLeft => 7,
//				_ => throw new NotImplementedException(),
//			};

//			return new Vector2(x, y);
//		}

//		public int GetFrameCount()
//		{
//			return (GameCharacter.State.CurrentState as ZombieState)?.CurrentState switch
//			{
//				ZombieStates.Stance => 4,
//				ZombieStates.Lurch => 8,
//				ZombieStates.Slam => 4,
//				ZombieStates.Bite => 4,
//				ZombieStates.Block => 2,
//				ZombieStates.HitAndDie => 6,
//				ZombieStates.CriticalDeath => 8,
//				_ => throw new NotImplementedException(),
//			};
//		}
//	}
//}
