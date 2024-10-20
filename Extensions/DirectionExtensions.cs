using RaylibPrototypeGame.Enums;
using System.Numerics;

namespace RaylibPrototypeGame.Extensions
{
	public static class DirectionExtensions
	{
		public static Vector2 GetFacingDirectionVector(this Direction direction)
		{
			switch (direction)
			{
				case Direction.Up:
					return new Vector2(0, -1);
				case Direction.Down:
					return new Vector2(0, 1);
				case Direction.Left:
					return new Vector2(-1, 0);
				case Direction.Right:
					return new Vector2(1, 0);
				case Direction.UpRight:
					return Vector2.Normalize(new Vector2(1, -1));
				case Direction.UpLeft:
					return Vector2.Normalize(new Vector2(-1, -1));
				case Direction.DownRight:
					return Vector2.Normalize(new Vector2(1, 1));
				case Direction.DownLeft:
					return Vector2.Normalize(new Vector2(-1, 1));
				default:
					return Vector2.Zero;
			}
		}
	}
}