using RayLibTemplate.Sandbox.GameObjects.Characters.Enemies.Zombie.Sprites;
using RayLibTemplate.Sandbox.GameObjects.Characters.Enemies.Zombie.States;
using RayLibTemplate.Sandbox.GameObjects.Characters.Player;
using System.Numerics;

namespace RayLibTemplate.Sandbox.GameObjects.Characters.Enemies.Zombie
{
	//128x128 tiles.  8 direction, 36 frames per direction.

	//Stance (4 frames)
	//Lurch(8 frames)
	//Slam(4 frames)
	//Bite(4 frames)
	//Block(2 frames)
	//Hit and Die(6 frames)
	//Critical Death(8 frames)

	internal class ZombieCharacter : Character, IGameObject, ICollidable
	{
		public Character? PlayerCharacter { get; set; }

		public override IEnumerable<Sprite> Sprites => new List<Sprite>() { new ZombieSprite() };

		public Vector2 Position { get; set; }

        public ZombieCharacter()
        {
			CollisionRadius = 25;
			Health = 50;
            TransitionToState(new ZombieStateStance(this));
        }

		public void Update()
		{
			CurrentState.Update();
		}
		
		public void Draw()
		{
			CurrentState.Draw();
		}

		public void HandleCollision(ICollidable otherCollidable)
		{
			if (otherCollidable is ZombieCharacter otherZombie)
			{
				float distance = Vector2.Distance(Position, otherZombie.Position);

				// If the other zombie's CollisionRadius overlaps with this zombie's CollisionRadius...
				if (distance < CollisionRadius + otherZombie.CollisionRadius)
				{
					Vector2 direction = Position - otherZombie.Position;
					Vector2 normalizedDirection = Vector2.Normalize(direction);
					Position += normalizedDirection * (CollisionRadius + otherZombie.CollisionRadius - distance) * 0.05f;
				}
			}
			else if (otherCollidable is PlayerCharacter)
			{
				PlayerCharacter = (Character)otherCollidable;

				float distance = Vector2.Distance(Position, ((IGameObject)PlayerCharacter).Position);
				
				if(distance > 100f)
				{
					TransitionToState(new ZombieStateStance(this));
				}

				if(CurrentState is ZombieStateSlam)
				{

					if (distance > CollisionRadius + PlayerCharacter.CollisionRadius)
					{
						TransitionToState(new ZombieStateLurch(this));
					}
				}

				if(CurrentState is ZombieStateLurch)
				{
					// Calculate the direction from the zombie to the player
					Vector2 movement = ((IGameObject)PlayerCharacter).Position - Position;

					Input.SetDirectionalMovementAI(movement, this);

					// Normalize the direction
					movement = Vector2.Normalize(movement);

					// Define a speed for the zombie
					float speed = 1.0f;

					// Move the zombie towards the player
					Position += movement * speed;

					if (distance < CollisionRadius + PlayerCharacter.CollisionRadius)
					{
						TransitionToState(new ZombieStateSlam(this));
					}
				}

				if (CurrentState is ZombieStateStance)
				{
					if (distance < 100f)
					{
						TransitionToState(new ZombieStateLurch(this));
					}
				}
			}
		}
	}
}
