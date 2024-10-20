using RaylibPrototypeGame.Components;

namespace RaylibPrototypeGame.Entites
{
    internal class Entity
    {
        private static int NextId = 0;

        public int Id { get; private set; }

        private readonly List<IComponent> _components = new List<IComponent>();

        public Entity()
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
            return component ?? throw new InvalidOperationException($"Component of type {typeof(T).Name} not found in Entity {Id}");
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
