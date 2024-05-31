using RayLibTemplate.Entities.Character;

namespace RayLibTemplate.Entities
{
	public class AnimatedSpriteManager
	{
		List<IAnimatedSprite> _sprites;

		public AnimatedSpriteManager()
		{
			_sprites = [];
		}

		public void AddSprite(IAnimatedSprite sprite)
		{
			_sprites.Add(sprite);
		}

		public bool RemoveSprite(IAnimatedSprite sprite)
		{
			return _sprites.Remove(sprite);
		}

		public void UpdateSprites()
		{
			foreach (var item in _sprites)
			{
				item.UpdateSprite();
			}
		}

		public void DrawSprites()
		{
			foreach (var item in _sprites)
			{
				item.DrawSprite();
			}
		}

		public void UnloadSprites()
		{
			foreach (var item in _sprites)
			{
				item.UnloadSprite();
			}
		}
	}
}
