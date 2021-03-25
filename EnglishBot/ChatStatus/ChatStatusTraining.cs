using System;

namespace EnglishBot
{
    public class ChatStatusTraining : ChatStatusDesc
    {
        public override BotData.eStatus GetNextStatus() => BotData.eStatus.TrainingType;
        public override string GetResponce() => "Тренировка начинается, выберете тип. Напишите Все или имя темы";
    }
}
