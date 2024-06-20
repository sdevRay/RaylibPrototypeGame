using RayLibTemplate.Sandbox2.Components;

namespace RayLibTemplate.Sandbox2.Systems
{
	internal class CooldownSystem : System
	{
		public override void Update(float deltaTime)
		{
			foreach (var entity in Entities)
			{
				if(entity.HasComponent<AttackComponent>())
				{
					var attack = entity.GetComponent<AttackComponent>();

					if (attack.CurrentCooldown > 0)
					{
						attack.CurrentCooldown -= deltaTime;
					}
				}
			}
		}
	}
}
