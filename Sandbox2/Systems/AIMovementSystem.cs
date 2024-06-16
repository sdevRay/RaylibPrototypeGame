using RayLibTemplate.Sandbox2.Components;
using RayLibTemplate.Sandbox2.Entites;
using RayLibTemplate.Sandbox2.Enums;
using System.Numerics;

namespace RayLibTemplate.Sandbox2.Systems
{
	internal class AIMovementSystem : System
	{
		private Entity Player { get; }

		public AIMovementSystem(Entity player)
		{
			Player = player;
		}

		public override void Update(float deltaTime)
		{
			var playerTransform = Player.GetComponent<TransformComponent>();

			foreach (var entity in Entities)
			{
				if (entity.HasComponent<TransformComponent>()
					&& entity.HasComponent<AIComponent>()
					&& entity.HasComponent<MovementComponent>()
					&& entity.HasComponent<StateComponent>()
					&& entity.HasComponent<FrameComponent>())
				{
					var transform = entity.GetComponent<TransformComponent>();
					var ai = entity.GetComponent<AIComponent>();
					var movement = entity.GetComponent<MovementComponent>();
					var state = entity.GetComponent<StateComponent>();
					var frame = entity.GetComponent<FrameComponent>();

					var distanceToPlayer = Vector2.Distance(transform.Position, playerTransform.Position);
					if (distanceToPlayer <= ai.AggroDistance)
					{
						if (state.CurrentState.Equals(ZombieStates.Stance))
							state.ChangeState(ZombieStates.Lurch);

						// Calculate direction towards the player
						var movementDrection = Vector2.Normalize(playerTransform.Position - transform.Position);

						// TODO: Have the ai face the player
						Direction direction = DetermineDirection(movementDrection);
						frame.Direction = direction;

						// Move the zombie towards the player
						transform.Position += movementDrection * movement.Speed * deltaTime;
					}
					else
					{
						if (state.CurrentState.Equals(ZombieStates.Lurch))
							state.ChangeState(ZombieStates.Stance);
					}
				}
			}
		}

		public Direction DetermineDirection(Vector2 movementDirection)
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
