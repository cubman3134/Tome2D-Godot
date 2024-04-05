using Models.Game.Server;
using Models.Game.Server.Connection;
using Models.Game.Server.Player;
using Models.Game.Server.ToClient.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tome2D.BusinessLogic.Map;
using Tome2D.Enums;
using Tome2D.Talkers;

namespace Tome2D.BusinessLogic.Server
{
    public class ServerMessageBL
    {
        public static object ProcessServerMessage(ServerMessageBase message)
        {
            switch (message)
            {
                case ChunkPlayerMessageResponse chunkMessageResponse:
                    MapBL.AddChunk(ActiveEntities.ActiveScene, chunkMessageResponse.MapTiles);
                    break;
                default:
                    break;
            }
            return null;
        }

        public static void SendRequestToServer(RequestMessageTypes requestMessage)
        {
            ServerMessageBase requestToSend = null;
            switch (requestMessage)
            {
                case RequestMessageTypes.RefreshLocalMap:
                    requestToSend = new ChunkPlayerMessage() { XLocation = ActiveEntities.Character.Position.X, YLocation = ActiveEntities.Character.Position.Y };
                    break;
            }
            if (requestToSend != null)
            {
                ServerTalker.Instance.SendMessage(requestToSend);
            }
        }
    }
}
