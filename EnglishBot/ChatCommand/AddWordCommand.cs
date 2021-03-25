using System;

namespace EnglishBot
{
    public class AddWordCommand : AbstractCommand, IChatTextCommand
    {
        public AddWordCommand()
        {
            CommandText = "/addword";
        }

        public BotData.eStatus ReturnStatus()
        {
            return BotData.eStatus.Adding;
        }
    }
}
