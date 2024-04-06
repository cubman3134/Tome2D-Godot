using Godot;
using Models.Game;
using Models.Game.Server;
using Models.Game.Server.Player;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Tome2D;
using Tome2D.BusinessLogic.Server;
using Tome2D.Talkers;

public partial class WorldHandler : Godot.Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        ActiveEntities.World = this;
        ActiveEntities.ActiveScene = GetTree().CurrentScene;
        if (ServerTalker.Instance.Connected)
        {
            
        }
        ServerMessageBL.SendRequestToServer(Tome2D.Enums.RequestMessageTypes.RefreshLocalMap);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{

	}
}
