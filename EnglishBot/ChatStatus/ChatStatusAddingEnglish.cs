using System;

namespace EnglishBot
{
    public class ChatStatusAddingEnglish : ChatStatusDesc
    {
        public override BotData.eStatus GetNextStatus() => BotData.eStatus.AddingSubject;
        public override string GetResponce() => "Введите тематику";
    }
}
