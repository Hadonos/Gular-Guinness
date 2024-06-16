using Godot;
using System;

public  abstract partial class ScrollingItem : CharacterBody2D
{
	public abstract override void _PhysicsProcess(double delta);
}
