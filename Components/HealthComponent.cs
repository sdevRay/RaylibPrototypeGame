namespace RayLibTemplate.Components
{
    internal class HealthComponent : IComponent
    {
        public float Health { get; set; }

        public void TakeDamage(float damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
        }

        public bool IsDead()
        {
            return Health <= 0;
        }
    }
}
