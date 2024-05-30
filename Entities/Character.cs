using RayLibTemplate.Entities.Controllers;
using System.Numerics;

namespace RayLibTemplate.Entities
{
	public abstract class Character<TState> : ICharacterState<TState>, IEntity, IUpdate, IDraw, IUnload
	{
		abstract public TState State { get; set; }
        abstract public Direction Direction { get; set; }
        abstract public int Speed { get; set; }
        abstract public Controller<TState> Controller { get; set; }
		abstract public AnimatedSpriteManager<TState> AnimatedSpriteManager { get; set; }
		public Vector2 Position { get; set; }

		public abstract Vector2 GetFrameOffSet();
        public abstract int GetFrameCount();

		public virtual void Update()
		{
			throw new NotImplementedException();
		}

		public virtual void Draw()
		{
			throw new NotImplementedException();
		}

		public virtual void Unload()
		{
			throw new NotImplementedException();
		}
	}
}
