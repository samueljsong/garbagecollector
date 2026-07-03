using Godot;
using System;

public partial class CollectableGenerator : Node2D
{
    [Export]
    public  PackedScene           BananaScene;
	private Vector2               _windowSize;
    private RandomNumberGenerator _rng = new RandomNumberGenerator();
    private Timer                 _bananaTimer;
	public override void _Ready()
    {
        _windowSize = GetViewportRect().Size;
        _rng.Randomize();
        
        _bananaTimer = GetNode<Timer>("BananaTimer");
        _bananaTimer.WaitTime = new Banana().SpawnInterval;
        _bananaTimer.Timeout += SpawnBanana; //Timeout is a signal
        _bananaTimer.Start();
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

    public void SpawnBanana()
    {
        GD.Print("Spawning Banana");
        Banana banana = BananaScene.Instantiate<Banana>();

        int x = _rng.RandiRange(40, (int)_windowSize.X);
        int y = _rng.RandiRange(40, (int)_windowSize.Y);

        banana.GlobalPosition = new Vector2(x, y);
        GetParent().AddChild(banana);
    }
}
