﻿using Raylib_cs;
using RayLibTemplate.Sandbox.GameObjects.Characters;
using System.Numerics;

namespace RayLibTemplate.Sandbox
{
	static class Input
	{
		static readonly List<(List<KeyboardKey> Keys, Direction Direction)> _keyMappings =
		[
			(new List<KeyboardKey> { KeyboardKey.D }, Direction.Right),
			(new List<KeyboardKey> { KeyboardKey.A }, Direction.Left),
			(new List<KeyboardKey> { KeyboardKey.W }, Direction.Up),
			(new List<KeyboardKey> { KeyboardKey.S }, Direction.Down),
			(new List<KeyboardKey> { KeyboardKey.W, KeyboardKey.D }, Direction.UpRight),
			(new List<KeyboardKey> { KeyboardKey.W, KeyboardKey.A }, Direction.UpLeft),
			(new List<KeyboardKey> { KeyboardKey.S, KeyboardKey.D }, Direction.DownRight),
			(new List<KeyboardKey> { KeyboardKey.S, KeyboardKey.A }, Direction.DownLeft),
		];

		static readonly List<MouseButton> _mouseButtons = new List<MouseButton> { MouseButton.Left, MouseButton.Right };

		public static bool TryGetMousesButtonDown(out MouseButton mouseButtonDown)
		{
			mouseButtonDown = default;
			foreach (var mouseButton in _mouseButtons)
			{
				if (Raylib.IsMouseButtonDown(mouseButton))
				{
					mouseButtonDown = mouseButton;
					return true;
				}
			}

			return false;
		}

		public static bool IsDirectionalKeyDown()
		{
			foreach (var mapping in _keyMappings)
			{
				foreach (var key in mapping.Keys)
				{
					if (Raylib.IsKeyDown(key))
					{
						return true;
					}
				}
			}
			return false;
		}

		public static bool IsDirectionalKeyPressed()
		{
			int keyCode = Raylib.GetKeyPressed();
			if (keyCode != default)
			{
				foreach (var mapping in _keyMappings)
				{
					if (mapping.Keys.Contains((KeyboardKey)keyCode))
					{
						return true;
					}
				}
			}

			return false;
		}

		public static void GetDirectionalMovement(out Direction direction, out Vector2 movement)
		{
			direction = Direction.Up;
			movement = Vector2.Zero;

			foreach (var mapping in _keyMappings)
			{
				if (mapping.Keys.All(key => Raylib.IsKeyDown(key)))
				{
					movement = mapping.Direction switch
					{
						Direction.Right => new Vector2(1, 0),
						Direction.Left => new Vector2(-1, 0),
						Direction.Up => new Vector2(0, -1),
						Direction.Down => new Vector2(0, 1),
						Direction.UpRight => new Vector2(1, -1),
						Direction.UpLeft => new Vector2(-1, -1),
						Direction.DownRight => new Vector2(1, 1),
						Direction.DownLeft => new Vector2(-1, 1),
						_ => Vector2.Zero,
					};

					movement = Vector2.Normalize(movement);
					direction = mapping.Direction;
				}
			}
		}

		public static void SetDirectionalMovementAI(Vector2 movement, Character character)
		{
			float tolerance = 15f;

			if (movement.X > tolerance && movement.Y < -tolerance)
				character.Direction = Direction.UpRight;
			else if (movement.X > tolerance && movement.Y > tolerance)
				character.Direction = Direction.DownRight;
			else if (movement.X < -tolerance && movement.Y < -tolerance)
				character.Direction = Direction.UpLeft;
			else if (movement.X < -tolerance && movement.Y > tolerance)
				character.Direction = Direction.DownLeft;
			else if (movement.X > tolerance)
				character.Direction = Direction.Right;
			else if (movement.X < -tolerance)
				character.Direction = Direction.Left;
			else if (movement.Y < -tolerance)
				character.Direction = Direction.Up;
			else if (movement.Y > tolerance)
				character.Direction = Direction.Down;
		}
	}
}
