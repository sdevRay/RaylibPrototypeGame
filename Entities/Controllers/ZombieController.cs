using RayLibTemplate.Entities.Enemies.Zombie;

namespace RayLibTemplate.Entities.Controllers
{
	public class ZombieController : Controller<ZombieState>
	{
		public override Character<ZombieState> Character { get; set; }

        public ZombieController(Character<ZombieState> character)
        {
			Character = character;
		}

		public override void Input()
		{
			//throw new NotImplementedException();
		}
	}
}
