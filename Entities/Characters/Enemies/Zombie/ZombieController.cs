//using RayLibTemplate.Entities.Characters.Player;
//using System.Numerics;

//namespace RayLibTemplate.Entities.Characters.Enemies.Zombie
//{
//	public class ZombieController : Controller
//	{
//		private Vector2 _playerDirection;
//		public ZombieController(GameCharacter gameCharacter) : base(gameCharacter)
//		{
//		}

//		public override void Input()
//		{
//			Vector2 direction = PlayerCharacter.Instance.Position - GameCharacter.Position;
//			_playerDirection = Vector2.Normalize(direction);

//			var zombieState = GameCharacter.State.CurrentState as ZombieState;
//			if (zombieState == null)
//				return;

//			switch (zombieState.CurrentState)
//			{
//				case ZombieStates.Lurch:
//					Lurch();
//					break;
//				case ZombieStates.Slam:
//					Slam();
//					break;
//			}
//		}

//		private void Slam()
//		{
//			// TODO: Remove health from player on timer
//			FacePlayer();
//		}

//		private void Lurch()
//		{
//			GameCharacter.Position += _playerDirection * GameCharacter.Speed;
//			FacePlayer();
//		}

//		void FacePlayer()
//		{
//			SetDirection(_playerDirection);
//		}

//		public void SetDirection(Vector2 direction)
//		{
//			float tolerance = 0.1f;

//			if (direction.X > tolerance && direction.Y < -tolerance)
//				GameCharacter.Direction = Direction.UpRight;
//			else if (direction.X > tolerance && direction.Y > tolerance)
//				GameCharacter.Direction = Direction.DownRight;
//			else if (direction.X < -tolerance && direction.Y < -tolerance)
//				GameCharacter.Direction = Direction.UpLeft;
//			else if (direction.X < -tolerance && direction.Y > tolerance)
//				GameCharacter.Direction = Direction.DownLeft;
//			else if (direction.X > tolerance)
//				GameCharacter.Direction = Direction.Right;
//			else if (direction.X < -tolerance)
//				GameCharacter.Direction = Direction.Left;
//			else if (direction.Y < -tolerance)
//				GameCharacter.Direction = Direction.Up;
//			else if (direction.Y > tolerance)
//				GameCharacter.Direction = Direction.Down;
//		}

//		public override void HandleCollision(IEntity otherEntity)
//		{
//			if (otherEntity is ZombieCharacter zombieCharacter)
//			{
//				// Calculate the direction from the other zombie to this zombie
//				Vector2 direction = GameCharacter.Position - zombieCharacter.Position;
//				direction = Vector2.Normalize(direction);

//				// Move this zombie away from the other zombie
//				GameCharacter.Position += direction * GameCharacter.Speed;
//			}
//		}
//	}
//}
