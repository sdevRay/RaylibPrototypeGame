using RayLibTemplate.Entities.Character;
using System.Numerics;

namespace RayLibTemplate.Entities.Enemies.Zombie
{
	class Zombie : GameCharacter
	{
		public override State State { get; set; } = new State(ZombieStates.Stance);
		public override Direction Direction { get; set; } = Direction.Left;
		public override int Speed { get; set; } = 1;
		public override Controller Controller { get; set; }
		public override IEnumerable<ICharacterSprite> CharacterSprites { get; set; }
		public override Vector2 Position { get; set; }

		public Zombie(Vector2 position)
		{
			Position = position;
			Controller = new ZombieController(this);
			CharacterSprites = new List<ICharacterSprite> { new ZombieSprite(this) };
		}
	}
}