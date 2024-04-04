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
	public ServerTalker ServerTalker { get; set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        ActiveEntities.World = this;
        ActiveEntities.ActiveScene = GetTree().CurrentScene;
        ServerTalker = new ServerTalker();
		ServerTalker.OnDataReceived += Client_OnDataReceived;
        bool successfullyConnected = ServerTalker.Connect(out string errorString);
        if (ServerTalker.Connected)
        {
            ChunkPlayerMessage message = new ChunkPlayerMessage() { XLocation = 0, YLocation = 0 };
            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Full };
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(message, typeof(object), settings);
            ServerTalker.SendString(jsonString);
        }
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{

	}

    private void Client_OnDataReceived(object sender, TcpSharp.OnClientDataReceivedEventArgs e)
    {
        var data = Encoding.UTF8.GetString(e.Data);
        var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Full };
        var deserializedMessage = Newtonsoft.Json.JsonConvert.DeserializeObject(data, settings);
        ServerMessageBL.ProcessServerMessage((ServerMessageBase)deserializedMessage);
        //Type messageType = deserializedBaseMessage?.ServerMessageType ?? typeof(ServerMessageBase);
        //var deserializedMessage = JsonSerializer.Deserialize(data, messageType) ?? new object();
        //ServerMessageBL.ProcessServerMessage((ServerMessageBase)deserializedMessage);
        Console.WriteLine(data);
    }
}
