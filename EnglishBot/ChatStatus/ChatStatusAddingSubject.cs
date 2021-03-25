using System;

namespace EnglishBot
{
    public class ChatStatusAddingSubject : ChatStatusDesc
    {
        public ChatStatusAddingSubject(string text) : base(text) { }
        public override BotData.eStatus GetNextStatus() => BotData.eStatus.Empty;
        public override string GetResponce() => $"Успешно! Слово {Text} добавлено в словарь";
    }
}
