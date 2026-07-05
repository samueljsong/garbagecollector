using Godot;
using System;

public partial class CloseUpgradeButton : Button
{
    private Cursor _cursor;
	private UpgradesOverlay _upgradesOverlay;
	public override void _Ready()
    {
        _cursor = GetNode<Cursor>("../../../Cursor");
        _upgradesOverlay = GetParent<UpgradesOverlay>();
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

    private void _on_close_upgrade_button_pressed()
    {
        _cursor.Visible = true;
        _cursor.ProcessMode = ProcessModeEnum.Pausable;
        Input.MouseMode = Input.MouseModeEnum.Hidden;
        _upgradesOverlay.Close();
    }
}
