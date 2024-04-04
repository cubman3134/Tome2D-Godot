using Models.Game.Server;
using Models.Game.Server.Connection;
using Models.Game.Server.ToClient.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tome2D.BusinessLogic.Map;

namespace Tome2D.BusinessLogic.Server
{
    public class ServerMessageBL
    {
        public static void ProcessServerMessage(ServerMessageBase message)
        {
            switch (message)
            {
                case ChunkPlayerMessageResponse chunkMessageResponse:
                    MapBL.AddChunk(, chunkMessageResponse.MapTiles);
                    break;
                default:
                    break;
            }
        }
    }
}
