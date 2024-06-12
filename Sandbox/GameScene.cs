using RayLibTemplate.Sandbox.GameObjects;

namespace RayLibTemplate.Sandbox
{
	internal class GameScene : IScene
	{
		public List<IGameObject> GameObjects { get; }

		public GameScene()
        {
			GameObjects = new List<IGameObject>();
        }

        public void AddGameObject(IGameObject gameObject)
        {
			GameObjects.Add(gameObject);
		}

        public void RemoveGameObject(IGameObject gameObject) 
        {
			GameObjects.Remove(gameObject); 
        }

        public void UpdateGameObjects()
        {
			HandleCollisions();

			foreach (var gameObject in GameObjects)
            {
				gameObject.Update();
			}
		}

		// This system is typically referred to as a "Broad Phase Collision Detection" system in game development. This system checks every game object against every other game object to determine potential interactions, such as collisions or proximity-based behaviors like aggro or attack range checks.

		private void HandleCollisions()
		{
			// Check for collisions between collidable game objects

			for (int i = 0; i < GameObjects.Count; i++)
			{
				for (int j = i + 1; j < GameObjects.Count; j++)
				{
					if (GameObjects[i] is ICollidable collidable && GameObjects[j] is ICollidable otherCollidable)
					{
						collidable.HandleCollision(otherCollidable);
						otherCollidable.HandleCollision(collidable);
					}
				}
			}
		}

		public void DrawGameObjects()
        {
			// Sort entities by Y position
			// This is ordered for characters and might not work for environments
			var sortedGameObjects = GameObjects.OrderBy(gameObject => gameObject.Position.Y);

			foreach (var gameObject in sortedGameObjects)
			{
				gameObject.Draw();
			}
		}
    }
}
