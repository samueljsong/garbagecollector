using Godot;
using System;

public partial class LeftButton : Button
{
    private CarouselContainer _carouselContainer;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
    {
        _carouselContainer = GetNode<CarouselContainer>("../CarouselContainer");
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
    {
    }

    private void _on_pressed()
    {
        GD.Print("Moving Left");
        _carouselContainer.Left();
    }
}
