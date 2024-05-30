namespace RayLibTemplate
{
	internal class EquipmentManager : IUpdate, IDraw, IUnload
	{
		List<AnimatedSprite> _sprites;

		public EquipmentManager()
		{
			_sprites = new List<AnimatedSprite>();
		}

		public void AddEquipment(AnimatedSprite equipment)
		{
			_sprites.Add(equipment);
		}

		public bool RemoveEquipment(AnimatedSprite equipment)
		{
			return _sprites.Remove(equipment);
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
