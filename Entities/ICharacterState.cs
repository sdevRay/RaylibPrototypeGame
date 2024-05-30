namespace RayLibTemplate.Entities
{
	public interface ICharacterState<TState>
	{
		TState State { get; set; }
	}
}
