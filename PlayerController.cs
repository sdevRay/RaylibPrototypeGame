using Raylib_cs;
using System.Numerics;

namespace RayLibTemplate
{
	public class PlayerController
	{
		public Player Player { get; set; }

		readonly List<(List<KeyboardKey> Keys, Direction Direction, PlayerState State)> _keyMappings =
		[
			(new List<KeyboardKey> { KeyboardKey.D }, Direction.Right, PlayerState.Running),
			(new List<KeyboardKey> { KeyboardKey.A }, Direction.Left, PlayerState.Running),
			(new List<KeyboardKey> { KeyboardKey.W }, Direction.Up, PlayerState.Running),
			(new List<KeyboardKey> { KeyboardKey.S }, Direction.Down, PlayerState.Running),
			(new List<KeyboardKey> { KeyboardKey.W, KeyboardKey.D }, Direction.UpRight, PlayerState.Running),
			(new List<KeyboardKey> { KeyboardKey.W, KeyboardKey.A }, Direction.UpLeft, PlayerState.Running),
			(new List<KeyboardKey> { KeyboardKey.S, KeyboardKey.D }, Direction.DownRight, PlayerState.Running),
			(new List<KeyboardKey> { KeyboardKey.S, KeyboardKey.A }, Direction.DownLeft, PlayerState.Running),
		];

        public PlayerController(Player player)
        {
			Player = player;
        }

        public void Input()
		{
			Vector2 movement = Vector2.Zero;
			Player.State = PlayerState.Stance;

			if (Raylib.IsMouseButtonDown(MouseButton.Left))
			{
				Player.State = PlayerState.MeleeSwing;
			}
			else if (Raylib.IsMouseButtonDown(MouseButton.Right))
			{
				Player.State = PlayerState.Block;
			}

			foreach (var mapping in _keyMappings)
			{
				if (mapping.Keys.All(key => Raylib.IsKeyDown(key)))
				{
					movement += mapping.Direction switch
					{
						Direction.Right => new Vector2(1, 0),
						Direction.Left => new Vector2(-1, 0),
						Direction.Up => new Vector2(0, -1),
						Direction.Down => new Vector2(0, 1),
						Direction.UpRight => new Vector2(1, -1),
						Direction.UpLeft => new Vector2(-1, -1),
						Direction.DownRight => new Vector2(1, 1),
						Direction.DownLeft => new Vector2(-1, 1),
						_ => Vector2.Zero,
					};
					Player.Direction = mapping.Direction;
					Player.State = mapping.State;
				}
			}

			if (movement != Vector2.Zero)
			{
				movement = Vector2.Normalize(movement);
				Player.Position += movement * Player.Speed;
			}

			//// TODO: For testing
			if (Raylib.IsKeyDown(KeyboardKey.Space))
			{
				Player.State = PlayerState.HitAndDie;
				return;
			}
		}

	}
}
