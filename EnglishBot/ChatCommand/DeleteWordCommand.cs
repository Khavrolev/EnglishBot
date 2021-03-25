using System;

namespace EnglishBot
{
    public class DeleteWordCommand : AbstractCommand, IChatTextCommand
    {
        public DeleteWordCommand()
        {
            CommandText = "/deleteword";
        }

        public BotData.eStatus ReturnStatus()
        {
            return BotData.eStatus.Deleting;
        }
    }
}
