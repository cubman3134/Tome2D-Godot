using Godot;
using GodotPlugins.Game;
using System;
using System.Collections.Generic;
using Tome2D;

public partial class CharacterHandler : WorldHandler
{
    private float _speed = 100f;

    public override void _Ready()
    {
        ActiveEntities.Character = this;
    }

    public void HandleInput(double delta)
    {
        float xMovement = 0f;
        float yMovement = 0f;
        if (Input.IsKeyPressed(Key.W))
        {
            yMovement += 1f;
        }
        if (Input.IsKeyPressed(Key.S))
        {
            yMovement -= 1f;
        }
        if (Input.IsKeyPressed(Key.D))
        {
            xMovement -= 1f;
        }
        if (Input.IsKeyPressed(Key.A))
        {
            xMovement += 1f;
        }
        if (xMovement != 0f || yMovement != 0f)
        {
            Position = new Vector2(Position.X + xMovement * _speed * (float)delta, Position.Y + yMovement * _speed * (float)delta);
        }
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        HandleInput(delta);
    }

    public override void _Input(InputEvent @event)
    {
        base._Input(@event);
    }
}
