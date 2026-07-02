using Godot;
using System;

public partial class Cursor : Area2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        Input.MouseMode = Input.MouseModeEnum.Hidden;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
    {
        GlobalPosition = GetGlobalMousePosition();

        if (Input.IsActionJustPressed("click"))
        {
            foreach (Area2D area in GetOverlappingAreas())
            {
                if (area is Banana banana)
                {
                    banana.Collect();
                }
            }
        }
    }
}
