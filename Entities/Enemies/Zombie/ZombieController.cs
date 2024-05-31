using RayLibTemplate.Entities.Character;

namespace RayLibTemplate.Entities.Enemies.Zombie
{
    public class ZombieController : Controller
    {
        public ZombieController(GameCharacter gameCharacter) : base(gameCharacter)
        {
		}
   
        public override void Input()
        {
            //throw new NotImplementedException();
        }
    }
}
