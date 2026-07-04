using Godot;
using System;

public partial class Cursor : Area2D
{
    private CollisionShape2D _collisionShape;
    private Line2D _line;
    private Sprite2D _sprite;

    public Game game;

	public override void _Ready()
	{
        _collisionShape = GetNode<CollisionShape2D>("CollisionShape2D");
        _line           = GetNode<Line2D>("Line2D");
        _sprite         = GetNode<Sprite2D>("Sprite2D");
        Input.MouseMode = Input.MouseModeEnum.Hidden;
        game            = GetTree().CurrentScene as Game;

        DrawCircleOutline();
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
        tween.TweenProperty(_sprite, "scale", new Vector2(0.8f, 0.8f), 0.1f);
        tween.TweenProperty(_sprite, "scale", new Vector2(1.0f, 1.0f), 0.1f);
    }

    private void DrawCircleOutline()
    {
        CircleShape2D circle = _collisionShape.Shape as CircleShape2D;

        if (circle == null)
            return;

        int points = 64;
        float radius = circle.Radius;

        _line.ClearPoints();
        _line.Width = 1;
        _line.Closed = true;
        _line.Position = _collisionShape.Position;

        for (int i = 0; i < points; i++)
        {
            float angle = Mathf.Tau * i / points;
            Vector2 point = new Vector2(
                Mathf.Cos(angle) * radius,
                Mathf.Sin(angle) * radius
            );

            _line.AddPoint(point);
        }
    }
}
