using System;

namespace EnglishBot
{
    public class ChatStatusAddingRussian : ChatStatusDesc
    {
        public override BotData.eStatus GetNextStatus() => BotData.eStatus.AddingEnglish;
        public override string GetResponce() => "Введите английское значение слова";
    }
}
