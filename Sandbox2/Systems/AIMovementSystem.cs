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
						var movementDirection = Vector2.Normalize(playerTransform.Position - transform.Position);

						transform.FacingDirection = movementDirection;
						frame.Direction = InputMovementSystem.DetermineDirection(movementDirection);

						// Move the zombie towards the player
						transform.Position += movementDirection * movement.Speed * deltaTime;
					}
					else
					{
						if (state.CurrentState.Equals(ZombieStates.Lurch))
							state.ChangeState(ZombieStates.Stance);
					}
				}
			}
		}
	}
}
