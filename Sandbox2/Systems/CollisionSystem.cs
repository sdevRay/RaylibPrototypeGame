using RayLibTemplate.Sandbox2.Components;
using System.Numerics;

namespace RayLibTemplate.Sandbox2.Systems
{
	internal class CollisionSystem : System
	{
		public override void Update(float deltaTime)
		{
			for (int i = 0; i < Entities.Count; i++)
			{
				for (int j = i + 1; j < Entities.Count; j++)
				{
					var entityA = Entities[i];
					var entityB = Entities[j];

					var transformA = entityA.GetComponent<TransformComponent>();
					var collisionA = entityA.GetComponent<CollisionComponent>();
					var transformB = entityB.GetComponent<TransformComponent>();
					var collisionB = entityB.GetComponent<CollisionComponent>();

					if (transformA != null && collisionA != null && transformB != null && collisionB != null)
					{
						if (IsColliding(transformA.Position, collisionA.Radius, transformB.Position, collisionB.Radius, out Vector2 penetrationDepth))
						{
							//HandleCollision(gameObjectA, gameObjectB);
							ResolveCollision(transformA, transformB, penetrationDepth);
						}
					}
				}
			}
		}

		private static bool IsColliding(Vector2 positionA, float radiusA, Vector2 positionB, float radiusB, out Vector2 penetrationDepth)
		{
			// Calculate the vector between the centers of the two circles
			Vector2 difference = positionA - positionB;

			// Calculate the squared distance between the centers
			float distanceSquared = difference.LengthSquared();

			// Calculate the sum of the radii
			float radiusSum = radiusA + radiusB;

			// Check if the distance between the centers is less than the sum of the radii
			if (distanceSquared < radiusSum * radiusSum)
			{
				float distance = MathF.Sqrt(distanceSquared);
				float penetrationDepthMagnitude = radiusSum - distance;
				penetrationDepth = difference * (penetrationDepthMagnitude / distance);
				return true;
			}

			penetrationDepth = Vector2.Zero;
			return false;
		}

		//private void HandleCollision(GameObject gameObjectA, GameObject gameObjectB)
		//{
		//	Console.WriteLine($"Collision detected between GameObject {gameObjectA.Id} and GameObject {gameObjectB.Id}");

		//	// Example collision handling: Player takes damage from enemy
		//	if (gameObjectA is Player && gameObjectB is Enemy)
		//	{
		//		var player = gameObjectA as Player;
		//		var enemy = gameObjectB as Enemy;
		//		player.TakeDamage(enemy.GetComponent<AttackComponent>().Damage);
		//	}
		//	else if (gameObjectA is Enemy && gameObjectB is Player)
		//	{
		//		var enemy = gameObjectA as Enemy;
		//		var player = gameObjectB as Player;
		//		player.TakeDamage(enemy.GetComponent<AttackComponent>().Damage);
		//	}
		//}

		private static void ResolveCollision(TransformComponent transformA, TransformComponent transformB, Vector2 penetrationDepth)
		{
			transformA.Position += penetrationDepth / 2;
			transformB.Position -= penetrationDepth / 2;
		}
	}
}
