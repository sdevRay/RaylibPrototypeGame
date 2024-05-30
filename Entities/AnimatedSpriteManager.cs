namespace RayLibTemplate.Entities
{
    public  class AnimatedSpriteManager<TState> : IUpdate, IDraw, IUnload
    {
        List<AnimatedSprite<TState>> _sprites;

        public AnimatedSpriteManager()
        {
			_sprites = [];
        }

        public void AddSprite(AnimatedSprite<TState> sprite)
        {
            _sprites.Add(sprite);
        }

        public bool RemoveSprite(AnimatedSprite<TState> sprite)
        {
            return _sprites.Remove(sprite);
        }

        public void Update()
        {
            foreach (var item in _sprites)
            {
                item.Update();
            }
        }

        public void Draw()
        {
            foreach (var item in _sprites)
            {
                item.Draw();
            }
        }

        public void Unload()
        {
            foreach (var item in _sprites)
            {
                item.Unload();
            }
        }
    }
}
