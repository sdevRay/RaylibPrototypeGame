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
				if (transform != null && draw != null)
				{
					Raylib.DrawTextureEx(draw.Texture, transform.Position, transform.Rotation, transform.Scale, Color.White);
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
