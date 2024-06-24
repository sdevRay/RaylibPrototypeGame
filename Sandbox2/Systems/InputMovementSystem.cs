using Raylib_cs;
using RayLibTemplate.Sandbox2.Components;
using RayLibTemplate.Sandbox2.Entities;
using RayLibTemplate.Sandbox2.Enums;
using System.Numerics;

namespace RayLibTemplate.Sandbox2.Systems
{
	internal class InputMovementSystem : System
	{
		static readonly List<(List<KeyboardKey> Keys, Direction Direction, Vector2 FacingDirection)> _keyMapping =
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

		private Player Player { get; }

		public InputMovementSystem(Player player)
		{
			Player = player;
		}

		public override void Update(float deltaTime)
		{
			if (!(Player.HasComponent<TransformComponent>()
				&& Player.HasComponent<MovementComponent>()
				&& Player.HasComponent<StateComponent>()))
			{
				return;
			}

			var transform = Player.GetComponent<TransformComponent>();
			var movement = Player.GetComponent<MovementComponent>();
			var state = Player.GetComponent<StateComponent>();

			Vector2 movementDirection = GetMovementDirection();
			Vector2 targetPosition = movementDirection != Vector2.Zero ? transform.Position + movementDirection : Raylib.GetMousePosition();
			float angle = MathF.Atan2(targetPosition.Y - transform.Position.Y, targetPosition.X - transform.Position.X);

			Direction newDirection = GetDirectionFromAngle(angle);
			if (transform.Direction != newDirection)
			{
				transform.Direction = newDirection;
			}

			if (movementDirection != Vector2.Zero)
			{
				if (!state.Equals(PlayerStates.Running))
				{
					state.ChangeState(PlayerStates.Running);
				}

				movementDirection = Vector2.Normalize(movementDirection);
				transform.Position += movementDirection * movement.Speed * deltaTime;
			}
			else if (state.Equals(PlayerStates.Running))
			{
				state.ChangeState(PlayerStates.Stance);
			}
		}

		private static Vector2 GetMovementDirection()
		{
			bool isKeyDownW = Raylib.IsKeyDown(KeyboardKey.W);
			bool isKeyDownA = Raylib.IsKeyDown(KeyboardKey.A);
			bool isKeyDownS = Raylib.IsKeyDown(KeyboardKey.S);
			bool isKeyDownD = Raylib.IsKeyDown(KeyboardKey.D);

			float x = 0;
			float y = 0;

			if (isKeyDownD) x += 1;
			if (isKeyDownA) x -= 1;
			if (isKeyDownW) y -= 1;
			if (isKeyDownS) y += 1;

			return new Vector2(x, y);
		}

		public static Direction GetDirectionFromAngle(float angleInRadians)
		{
			// Convert angle from radians to degrees
			float degrees = angleInRadians * (180f / MathF.PI);

			// Normalize the angle to be within the range [0, 360)
			degrees = (degrees + 360) % 360;

			// Determine the direction based on the angle
			if (degrees >= 337.5 || degrees < 22.5)
				return Direction.Right;
			else if (degrees >= 22.5 && degrees < 67.5)
				return Direction.DownRight;
			else if (degrees >= 67.5 && degrees < 112.5)
				return Direction.Down;
			else if (degrees >= 112.5 && degrees < 157.5)
				return Direction.DownLeft;
			else if (degrees >= 157.5 && degrees < 202.5)
				return Direction.Left;
			else if (degrees >= 202.5 && degrees < 247.5)
				return Direction.UpLeft;
			else if (degrees >= 247.5 && degrees < 292.5)
				return Direction.Up;
			else // degrees >= 292.5 && degrees < 337.5
				return Direction.UpRight;
		}
	}
}
