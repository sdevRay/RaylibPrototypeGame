using Raylib_cs;
using RayLibTemplate.Sandbox2.Components;

namespace RayLibTemplate.Sandbox2.Systems
{
	internal class DrawSystem : System
	{
		public override void Update(float deltaTime)
		{
			foreach (var gameObject in gameObjects)
			{
				var transform = gameObject.GetComponent<TransformComponent>();
				var draw = gameObject.GetComponent<DrawComponent>();
				var movement = gameObject.GetComponent<MovementComponent>();
				var frame = gameObject.GetComponent<FrameComponent>();
				var state = gameObject.GetComponent<StateComponent<PlayerState>>();
				
				if (transform != null && draw != null && movement != null && frame != null && state != null)
				{
					var frameState = frame.GetFrameForState(state.CurrentState);

					frame.Timer += Raylib.GetFrameTime();
					if (frame.Timer >= frame.FrameTime)
					{
						frame.Timer = 0;
						frame.CurrentFrame = (frame.CurrentFrame + 1) % frameState.FrameCount; // Loop through frames
					}

					Rectangle sourceRec = new((frame.CurrentFrame + frameState.FrameOffSetX) * draw.FrameWidth, draw.FrameHeight * frame.FrameOffSetY, draw.FrameWidth, draw.FrameHeight);

					Rectangle destRec = new(transform.Position.X, transform.Position.Y, draw.FrameWidth, draw.FrameHeight);
					Raylib.DrawTexturePro(draw.Texture, sourceRec, destRec, draw.Origin, 0, Color.White);

				}
			}
		}

		public void UnloadTextures()
		{
			foreach (var gameObject in gameObjects)
			{
				var draw = gameObject.GetComponent<DrawComponent>();
				if (draw != null)
				{
					Raylib.UnloadTexture(draw.Texture);
				}
			}
		}
	}
}
