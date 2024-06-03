using Raylib_cs;
using System.Numerics;

namespace RayLibTemplate.Sandbox.GameObjects.Characters.Player.States
{
	internal class PlayerStateRunning : State
	{
		readonly List<(List<KeyboardKey> Keys, Direction Direction)> _keyMappings =
			[		
				(new List<KeyboardKey> { KeyboardKey.D }, Direction.Right),
				(new List<KeyboardKey> { KeyboardKey.A }, Direction.Left),
				(new List<KeyboardKey> { KeyboardKey.W }, Direction.Up),
				(new List<KeyboardKey> { KeyboardKey.S }, Direction.Down),
				(new List<KeyboardKey> { KeyboardKey.W, KeyboardKey.D }, Direction.UpRight),
				(new List<KeyboardKey> { KeyboardKey.W, KeyboardKey.A }, Direction.UpLeft),
				(new List<KeyboardKey> { KeyboardKey.S, KeyboardKey.D }, Direction.DownRight),
				(new List<KeyboardKey> { KeyboardKey.S, KeyboardKey.A }, Direction.DownLeft),
			];

		public override float FrameOffSetX => 4;

		public override Vector2 FrameOffSet => new Vector2(FrameOffSetX, AnimatedSprite.GetFrameOffSetY(Direction));

		public override Direction Direction { get; set; }

		public override int FrameCount => 8;

		public override void Handle(IGameObject gameObject)
		{
			// Move right test
			Direction = Direction.Right;
			var movement = new Vector2(1, 0);
			gameObject.Position += movement * 1;

			if(Raylib.IsKeyDown(KeyboardKey.D))
			{
				_stateContext.TransitionTo(new PlayerStateStance());
			}
		}
	}
}
