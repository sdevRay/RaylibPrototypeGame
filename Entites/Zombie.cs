using RayLibTemplate.Components;
using RayLibTemplate.Enums;
using System.Numerics;

// 8 direction, 36 frames per direction.
//Stance(4 frames)
//Lurch(8 frames)
//Slam(4 frames)
//Bite(4 frames)
//Block(2 frames)
//Hit and Die (6 frames)
//Critical Death (8 frames)

namespace RayLibTemplate.Entites
{
	record ZombieStateStance(string Name) : IState;
    record ZombieStateLurch(string Name) : IState;

    internal static class ZombieStates
    {
        public static readonly ZombieStateStance Stance = new ZombieStateStance("Stance");
        public static readonly ZombieStateLurch Lurch = new ZombieStateLurch("Lurch");
        public static readonly ZombieStateLurch Slam = new ZombieStateLurch("Slam");
        public static readonly ZombieStateLurch HitAndDie = new ZombieStateLurch("HitAndDie");
    }

    internal class Zombie : Entity
    {
        public Zombie(Vector2 position)
        {
            AddComponent(new TransformComponent() { Position = position });
            AddComponent(new MovementComponent() { Speed = 25 });
            AddComponent(new StateComponent(ZombieStates.Stance));
            AddComponent(new AIComponent() { AggroDistance = 200 });
            AddComponent(new CollisionComponent() { Radius = 10 });
            AddComponent(new HealthComponent() { Health = 50 });
            AddComponent(new AttackComponent() { AttackRange = 20, Damage = 5 });

            AddComponent(new DrawComponent(rowCount: 8, columnCount: 36));
            var draw = GetComponent<DrawComponent>();
            draw.AddSprite("Zombie");

            AddComponent(new FrameComponent());
            var frame = GetComponent<FrameComponent>();
            frame.AddFrameState(ZombieStates.Stance, new FrameState(4, 0, AnimationType.PingPong));
            frame.AddFrameState(ZombieStates.Lurch, new FrameState(8, 4, AnimationType.Loop));    
            frame.AddFrameState(ZombieStates.Slam, new FrameState(4, 12, AnimationType.PingPong));    
            frame.AddFrameState(ZombieStates.HitAndDie, new FrameState(6, 22, AnimationType.SingleShot));
        }

        public void Destroy()
        {
            RemoveComponent<AIComponent>();
            RemoveComponent<MovementComponent>();
            RemoveComponent<AttackComponent>();
            RemoveComponent<HealthComponent>();
        }
    }
}
