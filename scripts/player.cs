using Godot;
using System;




public partial class player : CharacterBody2D
{
	
	//Vector2 vel = Vector2.Zero; in memorandium
	Vector2 initialPosition;
	
	float gravity = 5000;
	float accel = 10000;
	float friction = .1F;

	
	
	public override void _Ready()
	{
		Vector2 initialPosition = Position;
	}
		

	public override void _Process(double delta)
	{
		
		Vector2 vel = Velocity;
		
		var animated = GetNode<AnimatedSprite2D>("PelicanBody");
		
		
		if(Input.IsActionPressed("move_up"))
		{
			vel.Y -= accel * (float) delta; 
			animated.Play("gain");

			
		}else
		{
			animated.Play("fall");
		}
		
		if(!IsOnFloor()) 
		{
			vel.Y += gravity * (float) delta;
		}

		
		vel.Y = Mathf.MoveToward(vel.Y, 0, Math.Abs(vel.Y) * friction); //TODO: make friction curve and have alot of fun of form y=x^friction
	
		Velocity = vel;
		MoveAndSlide();
		

		
	}


	

}

