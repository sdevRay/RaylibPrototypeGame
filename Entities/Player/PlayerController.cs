using Raylib_cs;
using RayLibTemplate.Entities.Character;
using System.Numerics;

namespace RayLibTemplate.Entities.Player
{
    public class PlayerController : Controller
    {
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

        public PlayerController(GameCharacter gameCharacter) : base(gameCharacter)
        {
        }

        public override void Input()
        {
            Vector2 movement = Vector2.Zero;
			GameCharacter.State.CurrentState = PlayerState.Stance;

            if (Raylib.IsMouseButtonDown(MouseButton.Left))
            {
				GameCharacter.State.CurrentState = PlayerState.MeleeSwing;
            }
            else if (Raylib.IsMouseButtonDown(MouseButton.Right))
            {
				GameCharacter.State.CurrentState = PlayerState.Block;
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
					GameCharacter.Direction = mapping.Direction;
					GameCharacter.State.CurrentState = mapping.State;
                }
            }

            if (movement != Vector2.Zero)
            {
                movement = Vector2.Normalize(movement);
				GameCharacter.Position += movement * GameCharacter.Speed;
            }

            // TODO: For testing
            if (Raylib.IsKeyDown(KeyboardKey.Space))
            {
				GameCharacter.State.CurrentState = PlayerState.HitAndDie;
                return;
            }
        }
    }
}
