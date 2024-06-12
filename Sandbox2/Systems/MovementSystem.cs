using Raylib_cs;
using RayLibTemplate.Sandbox2.Components;
using System.Numerics;

namespace RayLibTemplate.Sandbox2.Systems
{
	internal class MovementSystem : System
	{
		public override void Update(float deltaTime)
		{
			foreach (var gameObject in gameObjects)
			{
				var transform = gameObject.GetComponent<TransformComponent>();
				var movement = gameObject.GetComponent<PlayerMovementComponent>();
				if (transform != null && movement != null)
				{
					Vector2 direction = Vector2.Zero;
					if (Raylib.IsKeyDown(KeyboardKey.W)) direction.Y -= 1;
					if (Raylib.IsKeyDown(KeyboardKey.S)) direction.Y += 1;
					if (Raylib.IsKeyDown(KeyboardKey.A)) direction.X -= 1;
					if (Raylib.IsKeyDown(KeyboardKey.D)) direction.X += 1;

					if (direction != Vector2.Zero)
					{
						direction = Vector2.Normalize(direction); // Normalize the direction vector
						transform.Position += direction * movement.Speed * deltaTime; // Apply delta time
					}
				}
			}
		}
	}
}
