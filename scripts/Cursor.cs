using Godot;
using System;

public partial class Cursor : Area2D
{
    public Game game;

	public override void _Ready()
	{
        Input.MouseMode = Input.MouseModeEnum.Hidden;
        game = GetTree().CurrentScene as Game;
	}


	public override void _Process(double delta)
    {
        GlobalPosition = GetGlobalMousePosition();

        if (Input.IsActionJustPressed("click"))
        {
            ClickAnimation();
            foreach (Area2D area in GetOverlappingAreas())
            {
                if (area is ICollectable collectable)
                {
                    collectable.DecreaseStrength();
                    if (collectable.Strength <= 0)
                        collectable.Collect(game);
                }
            }
        }
    }

    private void ClickAnimation()
    {
        var tween = CreateTween();
        tween.TweenProperty(this, "scale", new Vector2(1.2f, 1.2f), 0.1f);
        tween.TweenProperty(this, "scale", new Vector2(1.5f, 1.5f), 0.1f);
    }
}
