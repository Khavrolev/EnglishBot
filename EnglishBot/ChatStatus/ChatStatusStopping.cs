using System;

namespace EnglishBot
{
    public class ChatStatusStopping : ChatStatusDesc
    {
        public override BotData.eStatus GetNextStatus() => BotData.eStatus.Empty;
        public override string GetResponce() => "Процесс остановлен";
    }
}
