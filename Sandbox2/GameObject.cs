
using RayLibTemplate.Sandbox2.Components;

namespace RayLibTemplate.Sandbox2
{
    internal class GameObject
	{
		private static int NextId = 0;

		public int Id { get; private set; }

		private readonly List<IComponent> _components = [];

		public GameObject()
		{
			Id = NextId++;
		}

		public void AddComponent(IComponent component)
		{
			_components.Add(component);
		}

		public T GetComponent<T>() where T : class, IComponent
		{
			var component = _components.Find(component => component is T) as T;
			return component ?? throw new InvalidOperationException($"Component of type {typeof(T).Name} not found in GameObject {Id}");
		}

		public bool HasComponent<T>() where T : class, IComponent
		{
			return _components.Exists(component => component is T);
		}

		public void RemoveComponent<T>() where T : class, IComponent
		{
			_components.RemoveAll(component => component is T);
		}
	}
}
