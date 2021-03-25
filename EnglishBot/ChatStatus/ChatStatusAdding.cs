using System;

namespace EnglishBot
{
    public class ChatStatusAdding : ChatStatusDesc
    {
        public override BotData.eStatus GetNextStatus() => BotData.eStatus.AddingRussian;
        public override string GetResponce() => "Введите русское значение слова";
    }
}
