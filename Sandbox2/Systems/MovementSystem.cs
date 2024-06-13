using Raylib_cs;
using RayLibTemplate.Sandbox;
using RayLibTemplate.Sandbox2.Components;
using System.Numerics;

namespace RayLibTemplate.Sandbox2.Systems
{
	internal class MovementSystem : System
	{
		static readonly List<(List<KeyboardKey> Keys, Direction Direction, Vector2 Movement)> _keyMapping =
		[
			(new List<KeyboardKey> { KeyboardKey.D }, Direction.Right, new Vector2(1, 0)),
			(new List<KeyboardKey> { KeyboardKey.A }, Direction.Left, new Vector2(-1, 0)),
			(new List<KeyboardKey> { KeyboardKey.W }, Direction.Up, new Vector2(0, -1)),
			(new List<KeyboardKey> { KeyboardKey.S }, Direction.Down, new Vector2(0, 1)),
			(new List<KeyboardKey> { KeyboardKey.W, KeyboardKey.D }, Direction.UpRight, new Vector2(1, -1)),
			(new List<KeyboardKey> { KeyboardKey.W, KeyboardKey.A }, Direction.UpLeft, new Vector2(-1, -1)),
			(new List<KeyboardKey> { KeyboardKey.S, KeyboardKey.D }, Direction.DownRight, new Vector2(1, 1)),
			(new List<KeyboardKey> { KeyboardKey.S, KeyboardKey.A }, Direction.DownLeft, new Vector2(-1, 1)),
		];

		public override void Update(float deltaTime)
		{
			foreach (var gameObject in gameObjects)
			{
				var transform = gameObject.GetComponent<TransformComponent>();
				var movement = gameObject.GetComponent<MovementComponent>();
				var state = gameObject.GetComponent<StateComponent<PlayerState>>();
				var frame = gameObject.GetComponent<FrameComponent>();

				var movementDirection = Vector2.Zero;
				if (transform != null && movement != null && state != null && frame != null)
				{
					foreach (var mapping in _keyMapping)
					{
						if (mapping.Keys.All(key => Raylib.IsKeyDown(key)))
						{
							frame.Direction = mapping.Direction;
							movementDirection = mapping.Movement;
							movementDirection = Vector2.Normalize(movementDirection);
						}
					}

					if (movementDirection != Vector2.Zero)
					{
						if (state.CurrentState != PlayerState.Running)
							state.ChangeState(PlayerState.Running);

						movementDirection = Vector2.Normalize(movementDirection); // Normalize the direction vector
						transform.Position += movementDirection * movement.Speed * deltaTime; // Apply delta time

					}
					else
					{
						if (state.CurrentState != PlayerState.Stance)
							state.ChangeState(PlayerState.Stance);
					}
				}
			}
		}
	}
}
