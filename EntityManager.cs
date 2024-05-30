using RayLibTemplate.Entities;

namespace RayLibTemplate
{
	public class EntityManager
	{
		private readonly List<IEntity> _entities;

		public EntityManager()
		{
			_entities = [];
		}

		public void AddEntity(IEntity entity)
		{
			_entities.Add(entity);
		}

		public void RemoveEntity(IEntity entity)
		{
			_entities.Remove(entity);
		}

		public void UpdateEntities()
		{
			foreach (var entity in _entities)
			{
				if (entity is IUpdate updateableEntity)
				{
					updateableEntity.Update();
				}
			}
		}

		public void DrawEntities()
		{
			// Sort entities by Y position
			var sortedEntities = _entities.OrderBy(entity => entity.Position.Y);

			foreach (var entity in sortedEntities)
			{
				if (entity is IDraw drawableEntity)
				{
					drawableEntity.Draw();
				}
			}
		}

		public void UnloadEntities()
		{
			foreach (var entity in _entities)
			{
				if (entity is IUnload drawableEntity)
				{
					drawableEntity.Unload();
				}
			}
		}
	}

}
