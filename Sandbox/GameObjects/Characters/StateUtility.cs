using RayLibTemplate.Entities.Characters;

namespace RayLibTemplate.Sandbox.GameObjects.Characters
{
	static class StateUtility
	{
		public static int GetFrameOffSetY(Direction direction)
		{
			return direction switch
			{
				Direction.Left => 0,
				Direction.UpLeft => 1,
				Direction.Up => 2,
				Direction.UpRight => 3,
				Direction.Right => 4,
				Direction.DownRight => 5,
				Direction.Down => 6,
				Direction.DownLeft => 7,
				_ => throw new NotImplementedException(),
			};
		}
	}
}
