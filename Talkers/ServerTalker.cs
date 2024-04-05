using CommonData;
using Models.Game.Server;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tome2D.BusinessLogic.Server;

namespace Tome2D.Talkers
{
    public class ServerTalker : TomeClient.TomeClient
    {
        public static ServerTalker Instance = new ServerTalker();

        private void Client_OnDataReceived(object sender, TcpSharp.OnClientDataReceivedEventArgs e)
        {
            var data = Encoding.UTF8.GetString(e.Data);
            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Full };
            var deserializedMessage = Newtonsoft.Json.JsonConvert.DeserializeObject(data, settings);
            var response = ServerMessageBL.ProcessServerMessage((ServerMessageBase)deserializedMessage);

            //Type messageType = deserializedBaseMessage?.ServerMessageType ?? typeof(ServerMessageBase);
            //var deserializedMessage = JsonSerializer.Deserialize(data, messageType) ?? new object();
            //ServerMessageBL.ProcessServerMessage((ServerMessageBase)deserializedMessage);
            Console.WriteLine(data);
        }

        public ServerTalker() : base(CommonData.Constants.GameServerIP, CommonData.Constants.GameServerPortNumber)
        {
            OnDataReceived += Client_OnDataReceived;
            Connect(out string errorString);
        }
    }
}
