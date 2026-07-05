using Godot;
using System;

public partial class UpgradeButton : Button
{
    private Cursor _cursor;
	private UpgradesOverlay _upgradesOverlay;
	public override void _Ready()
    {
        _cursor = GetNode<Cursor>("../../Cursor");
        _upgradesOverlay = GetNode<UpgradesOverlay>("../UpgradesOverlay");
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
    {
    }

    private void _on_pressed()
    {
        _cursor.Visible = false;
        _cursor.ProcessMode = ProcessModeEnum.Disabled;
        Input.MouseMode = Input.MouseModeEnum.Visible;
        _upgradesOverlay.Open();
    }
}
