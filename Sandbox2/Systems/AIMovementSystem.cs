using RayLibTemplate.Sandbox2.Components;
using RayLibTemplate.Sandbox2.Entites;
using RayLibTemplate.Sandbox2.Entities;
using System.Numerics;

namespace RayLibTemplate.Sandbox2.Systems
{
	internal class AIMovementSystem : System
	{
		private Player Player { get; }

		public AIMovementSystem(Player player)
		{
			Player = player;
		}

		public override void Update(float deltaTime)
		{
			var playerTransform = Player.GetComponent<TransformComponent>();

			foreach (var entity in Entities)
			{
				if (!(entity.HasComponent<TransformComponent>()
					&& entity.HasComponent<AIComponent>()
					&& entity.HasComponent<MovementComponent>()
					&& entity.HasComponent<StateComponent>()
					&& entity.HasComponent<FrameComponent>()))
				{
					continue;
				}

				var state = entity.GetComponent<StateComponent>();

				if (state.Equals(ZombieStates.HitAndDie))
				{
					continue;
				}

				var transform = entity.GetComponent<TransformComponent>();
				var ai = entity.GetComponent<AIComponent>();
				var movement = entity.GetComponent<MovementComponent>();

				var distanceToPlayer = Vector2.Distance(transform.Position, playerTransform.Position);
				if (distanceToPlayer <= ai.AggroDistance)
				{
					ChangeStateIfNeeded(state, ZombieStates.Lurch);

					// Calculate direction towards the player and update position
					var movementDirection = Vector2.Normalize(playerTransform.Position - transform.Position);
					transform.Position += movementDirection * movement.Speed * deltaTime;

					// Update the frame direction based on the movement direction
					UpdateFrameDirection(transform, movementDirection);
				}
				else
				{
					ChangeStateIfNeeded(state, ZombieStates.Stance);
				}
			}
		}

		private static void ChangeStateIfNeeded(StateComponent state, IState targetState)
		{
			if (state.CurrentState != targetState)
			{
				state.ChangeState(targetState);
			}
		}

		private static void UpdateFrameDirection(TransformComponent transform, Vector2 movementDirection)
		{
			float angle = MathF.Atan2(movementDirection.Y, movementDirection.X);
			transform.Direction = InputMovementSystem.GetDirectionFromAngle(angle);
		}
	}
}
