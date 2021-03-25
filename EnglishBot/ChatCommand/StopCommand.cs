using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishBot
{
    public class StopCommand : AbstractCommand, IChatTextCommand
    {
        public StopCommand()
        {
            CommandText = "/stop";
        }

        public BotData.eStatus ReturnStatus()
        {
            return BotData.eStatus.Stopping;
        }
    }
}
