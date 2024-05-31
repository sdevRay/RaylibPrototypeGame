using RayLibTemplate.Entities.Character;
using System.Numerics;

namespace RayLibTemplate.Entities.Player.Equipment
{
	static class PlayerSpriteBase
	{
		public static int GetFrameCount(GameCharacter gameCharacter)
		{
			return gameCharacter.State.CurrentState switch
			{
				PlayerState.Stance => 4,
				PlayerState.Running => 8,
				PlayerState.MeleeSwing => 4,
				PlayerState.Block => 2,
				PlayerState.HitAndDie => 6,
				PlayerState.CastSpell => 4,
				PlayerState.ShootBow => 4,
				_ => throw new NotImplementedException(),
			};
		}

		public static Vector2 GetFrameOffSet(GameCharacter gameCharacter)
		{
			// TODO: Implement CastSpell and ShootBow states
			int x = gameCharacter.State.CurrentState switch
			{
				PlayerState.Stance => 0,
				PlayerState.Running => 4,
				PlayerState.MeleeSwing => 12,
				PlayerState.Block => 16,
				PlayerState.HitAndDie => 18,
				_ => throw new NotImplementedException(),
			};

			int y = gameCharacter.Direction switch
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

			return new Vector2(x, y);
		}
	}
}
