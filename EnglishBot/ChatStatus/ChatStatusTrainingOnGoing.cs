using System;

namespace EnglishBot
{
    public class ChatStatusTrainingOnGoing : ChatStatusDesc
    {
        public override BotData.eStatus GetNextStatus() => BotData.eStatus.TrainingOnGoing;
        public override string GetResponce() => "Тренировка продолжается";
    }
}
