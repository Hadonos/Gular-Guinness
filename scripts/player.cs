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
		
		if(Input.IsActionPressed("move_up"))
		{
			 accel.Y -= speed;
		}
		if(Input.IsActionPressed("move_down"))
		{
			 accel.Y += speed;
		}
		
		
		
		accel.Y += gravity;
		
		Mathf.MoveToward(accel.Y, 0, friction);
		
		vel += accel;
		
		
		
		Position += vel * (float)delta;
		

		
	}

}

