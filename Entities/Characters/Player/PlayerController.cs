//using Raylib_cs;
//using RayLibTemplate.Entities.Characters.Enemies.Zombie;
//using System.Numerics;

//namespace RayLibTemplate.Entities.Characters.Player
//{
//	public class PlayerController : Controller
//	{
//		readonly List<(List<KeyboardKey> Keys, Direction Direction, PlayerStates State)> _keyMappings =
//		[
//			(new List<KeyboardKey> { KeyboardKey.D }, Direction.Right, PlayerStates.Running),
//			(new List<KeyboardKey> { KeyboardKey.A }, Direction.Left, PlayerStates.Running),
//			(new List<KeyboardKey> { KeyboardKey.W }, Direction.Up, PlayerStates.Running),
//			(new List<KeyboardKey> { KeyboardKey.S }, Direction.Down, PlayerStates.Running),
//			(new List<KeyboardKey> { KeyboardKey.W, KeyboardKey.D }, Direction.UpRight, PlayerStates.Running),
//			(new List<KeyboardKey> { KeyboardKey.W, KeyboardKey.A }, Direction.UpLeft, PlayerStates.Running),
//			(new List<KeyboardKey> { KeyboardKey.S, KeyboardKey.D }, Direction.DownRight, PlayerStates.Running),
//			(new List<KeyboardKey> { KeyboardKey.S, KeyboardKey.A }, Direction.DownLeft, PlayerStates.Running),
//		];

//		public PlayerController(GameCharacter gameCharacter) : base(gameCharacter)
//		{
//		}

//		public override void HandleCollision(IEntity otherEntity)
//		{
//			if (otherEntity is ZombieCharacter zombieCharacter)
//			{
//				Vector2 direction = zombieCharacter.Position - GameCharacter.Position;
//				float distance = direction.Length();

//				// If the player and zombie positions are equal, direction will be NaN
//				if (float.IsNaN(direction.X) || float.IsNaN(direction.Y))
//				{
//					return;
//				}

//				direction = Vector2.Normalize(direction);

//				// Calculate the overlap distance
//				float overlap = GameCharacter.CollisionRadius + zombieCharacter.CollisionRadius - distance;

//				// If the player and the zombie are intersecting
//				if (overlap > 0)
//				{
//					// Adjust the positions of the player so that they are no longer intersecting
//					GameCharacter.Position -= overlap / 2 * direction;

//				}
//			}
//		}

//		public override void Input()
//		{
//			// Reset movement to idle
//			Vector2 movement = Vector2.Zero;
//			GameCharacter.State.CurrentState = new PlayerState(PlayerStates.Stance);

//			if (Raylib.IsMouseButtonDown(MouseButton.Left))
//			{
//				GameCharacter.State.CurrentState = new PlayerState(PlayerStates.MeleeSwing);
//			}
//			else if (Raylib.IsMouseButtonDown(MouseButton.Right))
//			{
//				GameCharacter.State.CurrentState = new PlayerState(PlayerStates.Block);
//			}

//			foreach (var mapping in _keyMappings)
//			{
//				if (mapping.Keys.All(key => Raylib.IsKeyDown(key)))
//				{
//					movement += mapping.Direction switch
//					{
//						Direction.Right => new Vector2(1, 0),
//						Direction.Left => new Vector2(-1, 0),
//						Direction.Up => new Vector2(0, -1),
//						Direction.Down => new Vector2(0, 1),
//						Direction.UpRight => new Vector2(1, -1),
//						Direction.UpLeft => new Vector2(-1, -1),
//						Direction.DownRight => new Vector2(1, 1),
//						Direction.DownLeft => new Vector2(-1, 1),
//						_ => Vector2.Zero,
//					};
//					GameCharacter.Direction = mapping.Direction;
//					GameCharacter.State.CurrentState = new PlayerState(mapping.State);
//				}
//			}

//			if (movement != Vector2.Zero)
//			{
//				movement = Vector2.Normalize(movement);
//				GameCharacter.Position += movement * GameCharacter.Speed;
//			}

//			// TODO: For testing
//			if (Raylib.IsKeyDown(KeyboardKey.Space))
//			{
//				GameCharacter.State.CurrentState = new PlayerState(PlayerStates.HitAndDie);
//				return;
//			}
//		}
//	}
//}
