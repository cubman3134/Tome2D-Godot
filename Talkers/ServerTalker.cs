using CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tome2D.Talkers
{
    public class ServerTalker : TomeClient.TomeClient
    {
        public ServerTalker() : base(Constants.GameServerIP, Constants.GameServerPortNumber) { }
    }
}
