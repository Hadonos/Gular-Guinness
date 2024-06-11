using Godot;
using System;

public partial class player : CharacterBody2D
{


	public override void _Process(double delta)
	{
		var Speed = 300;
		var velocity = Vector2.Zero; // The player's movement vector.

		if (Input.IsActionPressed("move_right"))
		{
			velocity.X += 1;
		}

		if (Input.IsActionPressed("move_left"))
		{
			velocity.X -= 1;
		}

		if (Input.IsActionPressed("move_down"))
		{
			velocity.Y += 1;
		}

		if (Input.IsActionPressed("move_up"))
		{
			velocity.Y -= 1;
		}

		var animatedSprite2D = GetNode<AnimatedSprite2D>("PelicanBody");

		if (velocity.Length() > 0)
		{
			velocity = velocity.Normalized() * Speed;
			animatedSprite2D.Play("gain");
		}
		else
		{
			animatedSprite2D.Play("fall");
		}
		
		Position += velocity * (float)delta;
	}

}
