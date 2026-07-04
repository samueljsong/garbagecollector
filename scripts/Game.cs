using Godot;
using System;

public partial class Game : Node2D
{
    [Export]
    private Node2D _hud;
    private Label _currencyLabel;
    public int Currency {get; private set;} = 0;

	public override void _Ready()
    {
        _currencyLabel = _hud.GetNode<Label>("Currency");
        UpdateCurrencyLabel();
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
    {
    }

    public void UpdateCurrencyLabel()
    {
        _currencyLabel.Text = Currency.ToString();
    }

    public void AddCurrency(int currency)
    {
        Currency += currency;
        UpdateCurrencyLabel();
    }
}
