using RayLibTemplate.Sandbox.GameObjects.Characters.Player.Sprites;
using RayLibTemplate.Sandbox.GameObjects.Characters.Player.States;
using System.Numerics;

namespace RayLibTemplate.Sandbox.GameObjects.Characters.Player
{
	//32-frame animation in 8 directions.

	//Stance(4 frames)
	//Running(8 frames) + 4
	//Melee Swing(4 frames) + 12
	//Block(2 frames) + 16
	//Hit and Die(6 frames) + 18
	//Cast Spell(4 frames) + 24
	//Shoot Bow(4 frames) + 28

	internal class PlayerCharacter : Character, IGameObject
	{	
		public override Direction Direction { get; set; }

		public Vector2 Position { get; set; }

		public override IEnumerable<Sprite> Sprites => new List<Sprite>() 
		{ 
			new LeatherArmorSprite(), 
			new MaleHeadOneSprite(),
			new LongSwordSprite()
		};

		public PlayerCharacter()
		{
			TransitionToState(new PlayerStateStance(this));
		}

		public void Update()
		{
			CurrentState.Update();
		}

		public void Draw()
		{
			CurrentState.Draw();
		}
	}
}
