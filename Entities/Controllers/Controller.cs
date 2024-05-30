namespace RayLibTemplate.Entities.Controllers
{
	public abstract class Controller<TState>
	{
		public abstract Character<TState> Character { get; set; }
		public abstract void Input();
	}
}
