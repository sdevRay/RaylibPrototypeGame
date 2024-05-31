using RayLibTemplate.Entities.Character;
using RayLibTemplate.Entities.Player.Sprites;
using System.Numerics;

namespace RayLibTemplate.Entities.Player
{
	public class Player : GameCharacter
	{
		public override State State { get; set; } = new State(PlayerState.Stance);
		public override Direction Direction { get; set; } = Direction.Left;
		public override int Speed { get; set; } = 2;
		public override Controller Controller { get; set; }
		public override IEnumerable<ICharacterSprite> CharacterSprites { get; set; }
		public override Vector2 Position { get; set; }

		public Player(Vector2 position)
		{
			Position = position;
			Controller = new PlayerController(this);
			CharacterSprites = new List<ICharacterSprite> 
			{ 
				new HeadSprite(this), 
				new WeaponSprite(this), 
				new ArmorSprite(this) 
			};
		}
	}
}