namespace RayLibTemplate.Sandbox.GameObjects.Characters
{
	abstract class Character
	{
		public abstract AnimatedSprite AnimatedSprite { get; set; }
		public abstract StateContext StateContext { get; set; }
		//public abstract int Speed { get; set; }
    }
}
