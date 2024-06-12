using System.Numerics;

namespace RayLibTemplate.Sandbox2.Components
{
	internal class TransformComponent : IComponent
    {
        public Vector2 Position { get; set; }

        public float Rotation { get; set; }

        public float Scale { get; set; }

        public TransformComponent(Vector2 position, float rotation = 0, float scale = 1)
        {
            Position = position;
            Rotation = rotation;
			Scale = scale;
		}
    }
}
