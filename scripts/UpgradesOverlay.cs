using Godot;
using System;

public partial class UpgradesOverlay : CanvasLayer
{
	private ColorRect _dim;
    private Node2D _carousel;
	public override void _Ready()
    {
        _dim      = GetNode<ColorRect>("ColorRect");
        _carousel = GetNode<Node2D>("CarouselContainer");

        Visible = false;
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
    {
    }

    public void Open()
    {
        Visible = true;
    }

    public void Close()
    {
        Visible = false;
    }
}
