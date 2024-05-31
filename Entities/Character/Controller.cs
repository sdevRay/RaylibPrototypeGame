namespace RayLibTemplate.Entities.Character
{
	public abstract class Controller
	{
		public GameCharacter GameCharacter { get; set; }

		protected Controller(GameCharacter gameCharacter)
		{
			GameCharacter = gameCharacter;
		}

		public abstract void Input();
	}
}
