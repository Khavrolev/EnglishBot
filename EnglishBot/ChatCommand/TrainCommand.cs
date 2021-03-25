using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishBot
{
    public class TrainCommand : AbstractCommand, IChatTextCommand
    {
        public TrainCommand()
        {
            CommandText = "/train";
        }

        public BotData.eStatus ReturnStatus()
        {
            return BotData.eStatus.Training;
        }
    }
}
