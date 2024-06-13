namespace RayLibTemplate.Sandbox.GameObjects
{
	internal interface ICollidable
	{
		public void HandleCollision(ICollidable otherCollidable);
	}
}
