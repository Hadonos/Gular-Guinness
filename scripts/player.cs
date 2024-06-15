using Godot;
using System;




public partial class player : CharacterBody2D
{
	Vector2 accel = Vector2.Zero;
	Vector2 vel = Vector2.Zero;
	
	float gravity = 5;
	float speed = 10;
	float friction = 1;
	
	
	
	public override void _Ready()
	{
		
	}
		

	public override void _Process(double delta)
	{
		
		
		
		var animated = GetNode<AnimatedSprite2D>("PelicanBody");
		
		
		if(GetViewport().GetMousePosition().Y < Position.Y)
		{
			 accel.Y -= speed;
			 animated.Play("gain");
			
		}else
		{
			animated.Play("fall");
		}
		
		
		if(Input.IsActionPressed("move_down"))
		{
			 accel.Y += speed;
		}
		
		
		if(!IsOnFloor())
		{
		accel.Y += gravity;
		vel += accel;
		}else
		{
			accel.Y = 0;
			vel.Y = 0;
		}
		
		Mathf.MoveToward(accel.Y, 0, friction);
		
		
		if(Input.IsActionPressed("debug_stop"))
		{
			vel = Vector2.Zero;
		}
		
		
		Position += vel * (float)delta;
		

		
	}

}

