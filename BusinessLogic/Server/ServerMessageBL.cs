using Models.Game.Server;
using Models.Game.Server.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tome2D.BusinessLogic.Server
{
    public class ServerMessageBL
    {
        public static void ProcessServerMessage(ServerMessageBase message)
        {
            switch (message)
            {
                case DisconnectServerMessage:
                    break;
                default:
                    break;
            }
        }
    }
}
