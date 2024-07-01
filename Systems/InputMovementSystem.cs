using Raylib_cs;
using RayLibTemplate.Components;
using RayLibTemplate.Entites;
using RayLibTemplate.Enums;
using RayLibTemplate.Extensions;
using System.Numerics;

namespace RayLibTemplate.Systems
{
    internal class InputMovementSystem : System
    {
        static readonly List<(List<KeyboardKey> Keys, Direction Direction, Vector2 FacingDirection)> _keyMapping =
        [
            (new List<KeyboardKey> { KeyboardKey.D }, Direction.Right, new Vector2(1, 0)),
            (new List<KeyboardKey> { KeyboardKey.A }, Direction.Left, new Vector2(-1, 0)),
            (new List<KeyboardKey> { KeyboardKey.W }, Direction.Up, new Vector2(0, -1)),
            (new List<KeyboardKey> { KeyboardKey.S }, Direction.Down, new Vector2(0, 1)),
            (new List<KeyboardKey> { KeyboardKey.W, KeyboardKey.D }, Direction.UpRight, new Vector2(1, -1)),
            (new List<KeyboardKey> { KeyboardKey.W, KeyboardKey.A }, Direction.UpLeft, new Vector2(-1, -1)),
            (new List<KeyboardKey> { KeyboardKey.S, KeyboardKey.D }, Direction.DownRight, new Vector2(1, 1)),
            (new List<KeyboardKey> { KeyboardKey.S, KeyboardKey.A }, Direction.DownLeft, new Vector2(-1, 1)),
        ];

        private Player Player { get; }

        public InputMovementSystem(Player player)
        {
            Player = player;
        }

        public override void Update(float deltaTime)
        {
            if (!(Player.HasComponent<TransformComponent>()
                && Player.HasComponent<MovementComponent>()
                && Player.HasComponent<StateComponent>()))
            {
                return;
            }


            var state = Player.GetComponent<StateComponent>();

            if (state.Equals(PlayerStates.HitAndDie))
            {
                return;
            }

            var transform = Player.GetComponent<TransformComponent>();
            var movement = Player.GetComponent<MovementComponent>();

            Vector2 movementDirection = GetMovementDirection();
            Vector2 targetPosition = movementDirection != Vector2.Zero ? transform.Position + movementDirection : Raylib.GetMousePosition();
            float angle = MathF.Atan2(targetPosition.Y - transform.Position.Y, targetPosition.X - transform.Position.X);

            Direction newDirection = angle.GetDirectionFromAngle();
            if (transform.Direction != newDirection)
            {
                transform.Direction = newDirection;
            }

            if (movementDirection != Vector2.Zero)
            {
                if (!state.Equals(PlayerStates.Running))
                {
                    state.ChangeState(PlayerStates.Running);
                }

                movementDirection = Vector2.Normalize(movementDirection);
                transform.Position += movementDirection * movement.Speed * deltaTime;
            }
            else if (state.Equals(PlayerStates.Running))
            {
                state.ChangeState(PlayerStates.Stance);
            }
        }

        private static Vector2 GetMovementDirection()
        {
            bool isKeyDownW = Raylib.IsKeyDown(KeyboardKey.W);
            bool isKeyDownA = Raylib.IsKeyDown(KeyboardKey.A);
            bool isKeyDownS = Raylib.IsKeyDown(KeyboardKey.S);
            bool isKeyDownD = Raylib.IsKeyDown(KeyboardKey.D);

            float x = 0;
            float y = 0;

            if (isKeyDownD) x += 1;
            if (isKeyDownA) x -= 1;
            if (isKeyDownW) y -= 1;
            if (isKeyDownS) y += 1;

            return new Vector2(x, y);
        }
    }
}
