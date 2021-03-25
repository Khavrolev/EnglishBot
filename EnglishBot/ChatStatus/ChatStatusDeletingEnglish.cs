using System;

namespace EnglishBot
{
    public class ChatStatusDeletingEnglish : ChatStatusDesc
    {
        public ChatStatusDeletingEnglish(string text) : base(text) { }
        public override BotData.eStatus GetNextStatus() => BotData.eStatus.Empty;
        public override string GetResponce() => $"Слово {Text} удалено";
    }
}
