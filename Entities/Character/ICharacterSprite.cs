using System.Numerics;

namespace RayLibTemplate.Entities.Character
{
	public interface ICharacterSprite
    {
		public GameCharacter GameCharacter { get; set; }
		public AnimatedSpriteManager AnimatedSpriteManager { get; set; }
		public Vector2 GetFrameOffSet();
        public int GetFrameCount();
		void Animate();
		void UnloadSprites();
	}
}
