using RayLibTemplate.Enums;

namespace RayLibTemplate.Extensions
{
	public static class FloatExtensions
	{
		public static Direction GetDirectionFromAngle(this float angleInRadians)
		{
			// Convert angle from radians to degrees
			float degrees = angleInRadians * (180f / MathF.PI);

			// Normalize the angle to be within the range [0, 360)
			degrees = (degrees + 360) % 360;

			// Determine the direction based on the angle
			if (degrees >= 337.5 || degrees < 22.5)
				return Direction.Right;
			else if (degrees >= 22.5 && degrees < 67.5)
				return Direction.DownRight;
			else if (degrees >= 67.5 && degrees < 112.5)
				return Direction.Down;
			else if (degrees >= 112.5 && degrees < 157.5)
				return Direction.DownLeft;
			else if (degrees >= 157.5 && degrees < 202.5)
				return Direction.Left;
			else if (degrees >= 202.5 && degrees < 247.5)
				return Direction.UpLeft;
			else if (degrees >= 247.5 && degrees < 292.5)
				return Direction.Up;
			else // degrees >= 292.5 && degrees < 337.5
				return Direction.UpRight;
		}
	}
}
