using Godot;
using System;

public partial class CarouselContainer : Node2D
{

    [Export] private float   _spacing            = 20.0f;
    [Export] private bool    _wraparoundEnabled  = false;
    [Export] private float   _wraparoundRadius   = 300.0f;
    [Export] private float   _wraparoundHeight   = 50.0f;
    [Export] private float   _smoothingSpeed     = 6.5f;
    [Export] private int     _selectedIndex      = 0;
    [Export] private bool    _followButtonFocus  = false;
    [Export] private Control _positionOffsetNode = null;

    [Export(PropertyHint.Range, "0.0,1.0")]        private float _opacityStrength = 0.35f;
    [Export(PropertyHint.Range, "0.0,1.0")]        private float _scaleStrength   = 0.25f;
    [Export(PropertyHint.Range, "0.01,0.99,0.01")] private float _scaleMin        = 0.1f;


	public override void _Ready()
	{
	}

	public override void _Process(double delta)
    {
        if (_positionOffsetNode == null || _positionOffsetNode.GetChildCount() == 0)
        {
            return;
        }

        _selectedIndex = Math.Clamp(_selectedIndex, 0, _positionOffsetNode.GetChildCount() - 1);

        foreach (Node child in _positionOffsetNode.GetChildren())
        {
            if (child is not Control item)
                continue;

            if (_wraparoundEnabled)
            {
                double  max_index_range = Math.Max(1, (_positionOffsetNode.GetChildCount() - 1) / 2.0);
                double  angle           = Math.Clamp((child.GetIndex() - _selectedIndex) / max_index_range, -1.0, 1.0) * Math.PI;
                float   x               = (float)Math.Sin(angle) * _wraparoundRadius;
                float   y               = (float)Math.Cos(angle) * _wraparoundHeight;
                Vector2 targetPosition  = new Vector2(x, y - _wraparoundHeight) - item.Size / 2.0f;
                
                item.Position = item.Position.Lerp(targetPosition, _smoothingSpeed * (float)delta);
            }
            else
            {
                float positionX = 0;

                if (item.GetIndex() > 0)
                    positionX =
                        ((Control)_positionOffsetNode.GetChild(item.GetIndex() - 1)).Position.X +
                        ((Control)_positionOffsetNode.GetChild(item.GetIndex() - 1)).Size.X +
                        _spacing;

                    item.Position = new Vector2(positionX, -item.Size.Y / 2.0f);
            }

            item.PivotOffset = item.Size / 2.0f;
            float targetScale = 1.0f - (_scaleStrength * Math.Abs(item.GetIndex() - _selectedIndex));
            targetScale = Math.Clamp(targetScale, _scaleMin, 1.0f);

            item.Scale = item.Scale.Lerp(
                Vector2.One * targetScale,
                _smoothingSpeed * (float)delta
            );

            float targetOpacity = 1.0f - (_opacityStrength * Math.Abs(item.GetIndex() - _selectedIndex));
            targetOpacity = Math.Clamp(targetOpacity, 0.0f, 1.0f);

            Color modulate = item.Modulate;
            modulate.A = Mathf.Lerp(modulate.A, targetOpacity, _smoothingSpeed * (float)delta);
            item.Modulate = modulate;

            if (item.GetIndex() == _selectedIndex)
                item.ZIndex = 1;
            else
                item.ZIndex = -Math.Abs(item.GetIndex() - _selectedIndex);

            if (_followButtonFocus && item.HasFocus())
                _selectedIndex = item.GetIndex();
        }

        if (_wraparoundEnabled)
        {
            _positionOffsetNode.Position = new Vector2(
                Mathf.Lerp(_positionOffsetNode.Position.X, 0.0f, _smoothingSpeed * (float)delta),
                _positionOffsetNode.Position.Y
            );
        }
        else
        {
            Control selected = (Control)_positionOffsetNode.GetChild(_selectedIndex);

            _positionOffsetNode.Position = new Vector2(
                Mathf.Lerp(
                    _positionOffsetNode.Position.X,
                    -(selected.Position.X + selected.Size.X / 2.0f),
                    _smoothingSpeed * (float)delta
                ),
                _positionOffsetNode.Position.Y
            );
        }
    }
}
