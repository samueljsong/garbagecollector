using Godot;
using System;

public partial class RightButton : Button
{
	private CarouselContainer _carouselContainer;
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
        GD.Print("Moving right");
        _carouselContainer.Right();
    }
}
