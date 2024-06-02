using RayLibTemplate.Sandbox.GameObjects;

namespace RayLibTemplate.Sandbox
{
    internal interface IScene
	{
		List<IGameObject> GameObjects { get; }

		void AddGameObject(IGameObject gameObject);

		void RemoveGameObject(IGameObject gameObject);

		void UpdateGameObjects();

		void DrawGameObjects();
	}
}
