namespace RayLibTemplate.Sandbox2.Systems
{
	internal abstract class System
	{
		protected List<GameObject> gameObjects = new List<GameObject>();

		public void AddGameObject(GameObject gameObject)
		{
			gameObjects.Add(gameObject);
		}

		public void RemoveGameObject(GameObject gameObject)
		{
			gameObjects.Remove(gameObject);
		}

		public void ClearGameObjects()
		{
			gameObjects.Clear();
		}

		public abstract void Update(float deltaTime);
	}
}
