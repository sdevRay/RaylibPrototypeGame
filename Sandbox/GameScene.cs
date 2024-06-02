
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
			foreach (var gameObject in GameObjects)
            {
				gameObject.Update();
			}
		}

        public void DrawGameObjects()
        {
			foreach (var gameObject in GameObjects)
			{
				gameObject.Draw();
			}
		}
    }
}
