using System.Numerics;

namespace RayLibTemplate
{
	public abstract class Character
	{
		abstract public Vector2 Position { get; set; }
		abstract public PlayerState State { get; set; }
		abstract public Direction Direction { get; set; }
		abstract public int Speed { get; set; }

		public abstract Vector2 GetFrameOffSet();
		public abstract int GetFrameCount();
	}
}
