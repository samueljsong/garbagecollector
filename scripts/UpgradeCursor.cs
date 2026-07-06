using Godot;
using System;

public partial class UpgradeCursor : Button
{
	private Cursor _cursor;
    private Game _game;
	public override void _Ready()
    {
        _cursor = GetNode<Cursor>("../../../../../../Cursor");
        _game = GetTree().CurrentScene as Game;
    }

	public override void _Process(double delta)
	{
	}

    private void _on_pressed()
    {

        

        CircleShape2D circle = _cursor.GetChild<CollisionShape2D>(1).Shape as CircleShape2D;
        circle.Radius *= 1.5f;
        _cursor.DrawCircleOutline();
    }
}
