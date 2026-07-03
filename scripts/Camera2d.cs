using Godot;
using System;

public partial class Camera2d : Camera2D
{

    public float ShakeIntensity  = 0.0f;
    public float ActiveShakeTime = 0.0f;
    public float ShakeDecay      = 5.0f;
    public float ShakeTime       = 0.0f;
    public float ShakeTimeSpeed  = 20.0f;
    public FastNoiseLite noise = new FastNoiseLite();
    

	public override void _Ready()
	{
	}

	public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("click"))
            ScreenShake(2, 0.1f);
    }

    public override void _PhysicsProcess(double delta)
    {
        if (ActiveShakeTime > 0)
        {
            ShakeTime += (float)delta * ShakeTimeSpeed;
            ActiveShakeTime -= (float)delta;

            Offset = new Vector2(
                noise.GetNoise2D(ShakeTime, 0) * ShakeIntensity,
                noise.GetNoise2D(0, ShakeTime) * ShakeIntensity
            );

            ShakeIntensity = Math.Max(ShakeIntensity - ShakeDecay * (float)delta, 0);
        }
        else
        {
            Offset = Offset.Lerp(Vector2.Zero, 10.5f * (float)delta);
        }
    }

    public void ScreenShake(int intensity, float time)
    {
        GD.Randomize();
        noise.Seed = (int)GD.Randi();
        noise.Frequency = 2.0f;

        ShakeIntensity = intensity;
        ActiveShakeTime = time;
        ShakeTime = 0.0f;
    }
}
