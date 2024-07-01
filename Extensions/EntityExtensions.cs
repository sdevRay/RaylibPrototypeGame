using RayLibTemplate.Components;
using RayLibTemplate.Entites;
using System.Numerics;

namespace RayLibTemplate.Extensions
{
	internal static class EntityExtensions
	{
		public static bool IsFacingTowardsAndWithinRange(this Entity entity, Entity otherEntity)
		{
			var otherTransform = otherEntity.GetComponent<TransformComponent>();
			var transform = entity.GetComponent<TransformComponent>();
			var attack = entity.GetComponent<AttackComponent>();

			if (otherTransform == null || transform == null || attack == null)
			{
				throw new InvalidOperationException("Required components are not attached to the entity.");
			}

			// Calculate the vector from the player to the other entity
			Vector2 toOther = otherTransform.Position - transform.Position;

			var facingDirection = transform.Direction.GetFacingDirectionVector();

			// Normalize the vectors
			Vector2 normalizedDirection = Vector2.Normalize(facingDirection);
			Vector2 normalizedToOther = Vector2.Normalize(toOther);

			// Calculate the dot product
			float dotProduct = Vector2.Dot(normalizedDirection, normalizedToOther);

			// Determine if the player is facing the other entity
			bool isFacingTowards = dotProduct > 0.8f;

			// Calculate the distance to the other entity
			float distanceToOther = Vector2.Distance(transform.Position, otherTransform.Position);

			// Check if the other entity is within attack range
			bool isWithinRange = distanceToOther <= attack.AttackRange;

			return isFacingTowards && isWithinRange;
		}
	}
}
