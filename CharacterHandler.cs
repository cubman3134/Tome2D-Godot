using Godot;
using GodotPlugins.Game;
using System;
using Tome2D;

public partial class CharacterHandler : WorldHandler
{
    public override void _Ready()
    {
        ActiveEntities.Character = this;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        if (Input.IsKeyPressed(Key.W))
        {
            Position = new Vector2(Position.X, Position.Y + 100 * (float)delta);
        }
    }

    public override void _Input(InputEvent @event)
    {
        base._Input(@event);
    }
}
