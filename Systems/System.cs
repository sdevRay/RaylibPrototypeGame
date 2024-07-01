using RayLibTemplate.Entites;

namespace RayLibTemplate.Systems
{
    internal abstract class System
    {
        protected List<Entity> Entities = new List<Entity>();

        public void AddEntity(Entity entity)
        {
            Entities.Add(entity);
        }

        public void RemoveEntity(Entity entity)
        {
            Entities.Remove(entity);
        }

        public void ClearEntities()
        {
            Entities.Clear();
        }

        public abstract void Update(float deltaTime);
    }
}
