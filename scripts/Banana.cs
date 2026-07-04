using Godot;
using System;
using System.Collections;

public partial class Banana : Area2D, ICollectable
{
    public int   Strength      { get; set; } = 3;
    public int   Cost          { get; set; } = 1;
    public float SpawnInterval { get; set; } = 2.0f;

    private AnimationPlayer _animationPlayer;
	public override void _Ready()
    {
        _animationPlayer = GetNode<AnimationPlayer>("HitFlashAnimationPlayer");
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

    public void Collect(Game game)
    {
        game.AddCurrency(1);
        QueueFree();
    }

    public void DecreaseStrength()
    {
        Strength--;
        _animationPlayer.Play("hit_flash");
    }
}
