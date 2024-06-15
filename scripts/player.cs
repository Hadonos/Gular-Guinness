using Godot;
using System;
using System.Runtime.ConstrainedExecution;




public partial class player : CharacterBody2D
{
	//max speed 750
	//Vector2 vel = Vector2.Zero; in memorandium
	Vector2 initialPosition;
	
	static readonly float upAngle = .5236F;
	static readonly float downAngle = 1.57F; 
	float gravity = 2500;
	float accel = 10000;
	float friction = .1F;
	
	
	public override void _Ready()
	{
		Vector2 initialPosition = Position;
	}
		

	public override void _Process(double delta)
	{
		float maxSpeed = 750;//Mathf.MoveToward(Math.Abs(accel - gravity), 0, Math.Abs(accel - gravity) * friction);

		Vector2 vel = Velocity;
		
		var animated = GetNode<AnimatedSprite2D>("%PelicanBody");
		
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

		//rotation
		float rotateAmt = vel.Y/maxSpeed;
		if(rotateAmt >= 0)
		{
			GetNode<Marker2D>("%PelicanCenter").Rotation = rotateAmt * downAngle;
		} else
		{
			GetNode<Marker2D>("%PelicanCenter").Rotation = rotateAmt * upAngle;
		}
		
		GD.Print(vel.Y);

		Velocity = vel;
		MoveAndSlide();
		

		
	}


	

}

