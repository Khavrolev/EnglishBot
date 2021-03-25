using System;

namespace EnglishBot
{
    public class ChatStatusDeleting : ChatStatusDesc
    {
        public override BotData.eStatus GetNextStatus() => BotData.eStatus.DeletingEnglish;
        public override string GetResponce() => "Введите английское значение слова, которое хотите удалить. Если передумали, напишите Отменить";
    }
}
