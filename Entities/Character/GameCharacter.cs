using System.Numerics;

namespace RayLibTemplate.Entities.Character
{
	public abstract class GameCharacter
    {
        public abstract State State { get; set; }
        public abstract Direction Direction { get; set; }
        public abstract int Speed { get; set; }
        public abstract Controller Controller { get; set; }
		public abstract IEnumerable<ICharacterSprite> CharacterSprites { get; set; }
		public abstract Vector2 Position { get; set; }

		protected virtual void AfterUpdate()
		{
			// Default implementation does nothing
		}

		public virtual void Update()
		{
			Controller.Input();

			AfterUpdate();
		}

		public virtual void Draw()
		{
			foreach (var sprite in CharacterSprites)
			{
				sprite.Animate();
			}
		}

		public virtual void Unload()
		{
			foreach (var sprite in CharacterSprites)
			{
				sprite.UnloadSprites();
			}
		}
	}
}
