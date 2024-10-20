﻿using Raylib_cs;
using RaylibPrototypeGame.Components;
using RaylibPrototypeGame.Enums;

namespace RaylibPrototypeGame.Systems
{
    internal class DrawSystem : System
    {
        public override void Update(float deltaTime)
        {
            // Sort game objects by their Y position
            var sortedEntities = Entities
                .Where(entity => entity.GetComponent<TransformComponent>() != null && entity.GetComponent<DrawComponent>() != null)
                .OrderBy(entity => entity.GetComponent<TransformComponent>().Position.Y);

            foreach (var entity in sortedEntities)
            {
                if (!(entity.HasComponent<TransformComponent>()
                    && entity.HasComponent<DrawComponent>()
                    && entity.HasComponent<FrameComponent>()
                    && entity.HasComponent<StateComponent>()))
                {
                    continue;
                }

                var transform = entity.GetComponent<TransformComponent>();
                var draw = entity.GetComponent<DrawComponent>();
                var frame = entity.GetComponent<FrameComponent>();
                var state = entity.GetComponent<StateComponent>();

                var frameState = frame.GetFrameForState(state.CurrentState);

                frame.Timer += Raylib.GetFrameTime();
                if (frameState.AnimationType == AnimationType.Loop)
                {
                    if (frame.Timer >= frame.FrameTime)
                    {
                        frame.Timer = 0;
                        frame.CurrentFrame = (frame.CurrentFrame + 1) % frameState.FrameCount; // Loop through frames
                    }
                }
                else if (frameState.AnimationType == AnimationType.PingPong)
                {
                    if (frame.Timer >= frame.FrameTime)
                    {
                        frame.Timer = 0;

                        if (frame.IsPlayingForward)
                        {
                            frame.CurrentFrame = (frame.CurrentFrame + 1) % frameState.FrameCount;

                            if (frame.CurrentFrame >= frameState.FrameCount - 1)
                            {
                                frame.IsPlayingForward = false;
                            }
                        }
                        else
                        {
                            frame.CurrentFrame = (frame.CurrentFrame - 1 + frameState.FrameCount) % frameState.FrameCount;

                            if (frame.CurrentFrame <= 0)
                            {
                                frame.IsPlayingForward = true;

                                if (frame.HasCompletedPingPong == false)
                                    frame.HasCompletedPingPong = true;
                            }
                        }
                    }
                }
                else if (frameState.AnimationType == AnimationType.SingleShot)
                {
                    if (frame.Timer >= frame.FrameTime)
                    {
                        if (frame.CurrentFrame < frameState.FrameCount - 1)
                        {
                            frame.Timer = 0;
                            frame.CurrentFrame++; // Move to the next frame
                        }
                        else
                        {
                            // Keep the animation on the last frame and do not reset the timer.
                            // This ensures the animation stops on the last frame.
                            // Optionally, you can add logic here to handle what happens when the animation ends.
                        }
                    }
                }

                foreach (var sprite in draw.Sprites)
                {
                    var frameOffSetY = GetFrameOffSetY(transform.Direction);

                    Rectangle sourceRec = new((frame.CurrentFrame + frameState.FrameOffSetX) * sprite.FrameWidth, sprite.FrameHeight * frameOffSetY, sprite.FrameWidth, sprite.FrameHeight);

                    Rectangle destRec = new(transform.Position.X, transform.Position.Y, sprite.FrameWidth, sprite.FrameHeight);
                    Raylib.DrawTexturePro(sprite.Texture, sourceRec, destRec, sprite.Origin, 0, Color.White);
                }
            }
        }

        private static int GetFrameOffSetY(Direction direction)
        {
            return direction switch
            {
                Direction.Left => 0,
                Direction.UpLeft => 1,
                Direction.Up => 2,
                Direction.UpRight => 3,
                Direction.Right => 4,
                Direction.DownRight => 5,
                Direction.Down => 6,
                Direction.DownLeft => 7,
                _ => throw new InvalidOperationException($"Unhandled direction: {direction}")
            };
        }
    }
}
