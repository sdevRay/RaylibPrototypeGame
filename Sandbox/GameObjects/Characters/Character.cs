namespace RayLibTemplate.Sandbox.GameObjects.Characters
{
	abstract class Character
	{
		public abstract AnimatedSprite AnimatedSprite { get; set; }
		public abstract State State { get; set; }
		public abstract int Speed { get; set; }
    }
}
