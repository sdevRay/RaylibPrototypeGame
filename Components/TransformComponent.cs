using RayLibTemplate.Enums;
using System.Numerics;

namespace RayLibTemplate.Components
{
    internal class TransformComponent : IComponent
    {
        public Vector2 Position { get; set; }

        public float Rotation { get; set; } = 0;

        public float Scale { get; set; } = 1;

        public Direction Direction { get; set; }
    }
}
