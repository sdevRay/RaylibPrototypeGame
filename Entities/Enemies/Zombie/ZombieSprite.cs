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

	internal class ZombieSprite : AnimatedSprite<ZombieState>
	{
		public ZombieSprite(Character<ZombieState> character) : base(rowCount: 36, columnCount: 8, fileName: "Assets/Zombie/zombie_0.png", character)
		{
		}
	}
}
