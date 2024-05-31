using RayLibTemplate.Entities.Character;

namespace RayLibTemplate
{
	// TODO: This is a stub class only setup for GameCharacter's.
	// Implement or abstract this class to manage entities in the game.
	public class EntityManager
	{
		private readonly List<GameCharacter> _entities;

		public EntityManager()
		{
			_entities = [];
		}

		public void AddEntity(GameCharacter entity)
		{
			_entities.Add(entity);
		}

		public void RemoveEntity(GameCharacter entity)
		{
			_entities.Remove(entity);
		}

		public void UpdateEntities()
		{
			foreach (var entity in _entities)
			{
				entity.Update();
			}
		}

		public void DrawEntities()
		{
			// Sort entities by Y position
			var sortedEntities = _entities.OrderBy(entity => entity.Position.Y);

			foreach (var entity in sortedEntities)
			{
				entity.Draw();
			}
		}

		public void UnloadEntities()
		{
			foreach (var entity in _entities)
			{
				entity.Unload();
			}
		}
	}

}
