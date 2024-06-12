using System.Numerics;

namespace RayLibTemplate.Sandbox.GameObjects
{
    public interface IGameObject
    {
        public Vector2 Position { get; set; }
        
        public void Update();
        
        public void Draw();
    }
}
