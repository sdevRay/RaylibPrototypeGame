using System.Numerics;

namespace RayLibTemplate.Sandbox.GameObjects
{
    internal interface IGameObject
    {
        public Vector2 Position { get; set; }
        public void Update();
        public void Draw();
        public void Destroy();
    }
}
