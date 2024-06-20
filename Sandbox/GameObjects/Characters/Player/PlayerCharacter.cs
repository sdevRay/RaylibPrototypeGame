//using RayLibTemplate.Sandbox.GameObjects.Characters.Enemies.Zombie;
//using RayLibTemplate.Sandbox.GameObjects.Characters.Player.Sprites;
//using RayLibTemplate.Sandbox.GameObjects.Characters.Player.States;
//using System.Numerics;

//namespace RayLibTemplate.Sandbox.GameObjects.Characters.Player
//{
//	//32-frame animation in 8 directions.

//	//Stance(4 frames)
//	//Running(8 frames) + 4
//	//Melee Swing(4 frames) + 12
//	//Block(2 frames) + 16
//	//Hit and Die(6 frames) + 18
//	//Cast Spell(4 frames) + 24
//	//Shoot Bow(4 frames) + 28

//	internal class PlayerCharacter : Character, IGameObject, ICollidable
//	{	
//		public Vector2 Position { get; set; }

//		public override IEnumerable<Sprite> Sprites => new List<Sprite>() 
//		{ 
//			new LeatherArmorSprite(), 
//			new MaleHeadOneSprite(),
//			new LongSwordSprite(),
//			new ShieldSprite()
//		};

//		public PlayerCharacter()
//		{
//			CollisionRadius = 25;
//			Health = 100f;
//			TransitionToState(new PlayerStateStance(this));
//		}

//		public void Update()
//		{
//			CurrentState.Update();
//		}

//		public void Draw()
//		{
//			CurrentState.Draw();
//		}

//		public void HandleCollision(ICollidable otherCollidable)
//		{
//			if (otherCollidable is ZombieCharacter zombie)
//			{
//				float distance = Vector2.Distance(Position, zombie.Position);

//				// If the zombie's CollisionRadius overlaps with this player's CollisionRadius...
//				if (distance < CollisionRadius + zombie.CollisionRadius)
//				{
//					// Calculate the direction from the zombie to this player
//					Vector2 direction = Position - zombie.Position;

//					// Normalize the direction
//					Vector2 normalizedDirection = Vector2.Normalize(direction);

//					// Move this player away from the zombie
//					Position += normalizedDirection * (CollisionRadius + zombie.CollisionRadius - distance) * 0.05f; // Adjust the multiplier as needed
//				}
//			}
//		}
//	}
//}
