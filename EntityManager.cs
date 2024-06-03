//using RayLibTemplate.Entities.Characters;
//using RayLibTemplate.Entities.Characters.Enemies.Zombie;
//using RayLibTemplate.Entities.Characters.Player;
//using System.Numerics;

//namespace RayLibTemplate
//{
//	// TODO: This is a stub class only setup for GameCharacter's.
//	// Implement or abstract this class to manage entities in the game.
//	public class EntityManager
//	{
//		private readonly List<GameCharacter> _entities;

//		public EntityManager()
//		{
//			_entities = [];
//		}

//		public void AddEntities(IEnumerable<GameCharacter> entities)
//		{
//			_entities.AddRange(entities);
//		}

//		public void AddEntity(GameCharacter entity)
//		{
//			_entities.Add(entity);
//		}

//		public void RemoveEntity(GameCharacter entity)
//		{
//			_entities.Remove(entity);
//		}

//		public void UpdateEntities()
//		{
//			foreach (var entity in _entities)
//			{
//				if (entity is ZombieCharacter zombieCharacter)
//				{
//					float distance = Vector2.Distance(zombieCharacter.Position, PlayerCharacter.Instance.Position);

//					// TODO: Set behavior based on distance, in those methods do other things and set state
//					// That way an Attack() method can Slam and then go back to Stance on interval
//					if (distance < 25)
//					{
//						zombieCharacter.State.CurrentState = new ZombieState(ZombieStates.Slam);
//					}
//					else if (distance < 100)
//					{
//						zombieCharacter.State.CurrentState = new ZombieState(ZombieStates.Lurch);
//					}
//					else
//					{
//						zombieCharacter.State.CurrentState = new ZombieState(ZombieStates.Stance);
//					}
//				}

//				entity.Update();
//			}

//			CheckCollisions();
//		}

//		public void CheckCollisions()
//		{
//			for (int i = 0; i < _entities.Count; i++)
//			{
//				for (int j = i + 1; j < _entities.Count; j++)
//				{
//					if (IsColliding(_entities[i], _entities[j]))
//					{
//						_entities[i].Controller.HandleCollision(_entities[j]);
//						_entities[j].Controller.HandleCollision(_entities[i]);
//					}
//				}
//			}
//		}

//		public static bool IsColliding(GameCharacter gameCharacter1, GameCharacter gameCharacter2)
//		{
//			float distance = Vector2.Distance(gameCharacter1.Position, gameCharacter2.Position);
//			return distance < 25;
//		}

//		public void DrawEntities()
//		{
//			// Sort entities by Y position
//			var sortedEntities = _entities.OrderBy(entity => entity.Position.Y);

//			foreach (var entity in sortedEntities)
//			{
//				entity.Draw();
//			}
//		}

//		public void UnloadEntities()
//		{
//			foreach (var entity in _entities)
//			{
//				entity.Unload();
//			}
//		}
//	}

//}
