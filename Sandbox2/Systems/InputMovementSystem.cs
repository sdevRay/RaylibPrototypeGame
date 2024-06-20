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
			if (Player.HasComponent<TransformComponent>()
				&& Player.HasComponent<MovementComponent>()
				&& Player.HasComponent<StateComponent>()
				&& Player.HasComponent<FrameComponent>()
				&& Player.HasComponent<AttackComponent>())
			{
				var transform = Player.GetComponent<TransformComponent>();
				var movement = Player.GetComponent<MovementComponent>();
				var state = Player.GetComponent<StateComponent>();
				var frame = Player.GetComponent<FrameComponent>();

				var movementDirection = GetMovementDirection();

				if (movementDirection != Vector2.Zero)
				{
					if (state.CurrentState.Equals(PlayerStates.MeleeSwing) && frame.CurrentFrame <= 2)
						return;

					if (!state.CurrentState.Equals(PlayerStates.Running))
						state.ChangeState(PlayerStates.Running);

					movementDirection = Vector2.Normalize(movementDirection); // Normalize the direction vector
					transform.FacingDirection = movementDirection;
					frame.Direction = DetermineDirection(movementDirection);
					transform.Position += movementDirection * movement.Speed * deltaTime; // Apply delta time
				}
				else if (state.CurrentState.Equals(PlayerStates.Running))
				{
					state.ChangeState(PlayerStates.Stance);
				}
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

		public static Direction DetermineDirection(Vector2 movementDirection)
		{
			// Calculate the angle in radians and then convert to degrees
			float angle = MathF.Atan2(movementDirection.Y, movementDirection.X) * (180 / MathF.PI);

			// Normalize the angle to be within the range [0, 360)
			if (angle < 0) angle += 360;

			// Determine the direction based on the angle
			if (angle >= 337.5 || angle < 22.5)
				return Direction.Right;
			else if (angle >= 22.5 && angle < 67.5)
				return Direction.DownRight;
			else if (angle >= 67.5 && angle < 112.5)
				return Direction.Down;
			else if (angle >= 112.5 && angle < 157.5)
				return Direction.DownLeft;
			else if (angle >= 157.5 && angle < 202.5)
				return Direction.Left;
			else if (angle >= 202.5 && angle < 247.5)
				return Direction.UpLeft;
			else if (angle >= 247.5 && angle < 292.5)
				return Direction.Up;
			else // angle >= 292.5 && angle < 337.5
				return Direction.UpRight;
		}
	}
}
