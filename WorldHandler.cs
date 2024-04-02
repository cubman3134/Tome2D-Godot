using Godot;
using Models.Game.Server;
using System;
using System.Text;
using System.Text.Json;
using Tome2D;
using Tome2D.BusinessLogic.Server;
using Tome2D.Talkers;

public partial class WorldHandler : Godot.Node2D
{
	public ServerTalker ServerTalker { get; set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        ActiveEntities.World = this;
		ServerTalker = new ServerTalker();
		ServerTalker.OnDataReceived += Client_OnDataReceived;
        bool successfullyConnected = ServerTalker.Connect(out string errorString);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{

	}

    public void Test()
    {

    }

    private void Client_OnDataReceived(object sender, TcpSharp.OnClientDataReceivedEventArgs e)
    {
        var data = Encoding.UTF8.GetString(e.Data);
        var deserializedBaseMessage = JsonSerializer.Deserialize<ServerMessageBase>(data);
        Type messageType = deserializedBaseMessage?.ServerMessageType ?? typeof(ServerMessageBase);
        var deserializedMessage = JsonSerializer.Deserialize(data, messageType) ?? new object();
        ServerMessageBL.ProcessServerMessage((ServerMessageBase)deserializedMessage);
        Console.WriteLine(data);
    }
}
