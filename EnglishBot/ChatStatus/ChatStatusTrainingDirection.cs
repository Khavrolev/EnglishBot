using System;

namespace EnglishBot
{
    public class ChatStatusTrainingDirection : ChatStatusDesc
    {
        public override BotData.eStatus GetNextStatus() => BotData.eStatus.TrainingOnGoing;
        public override string GetResponce() => "Тренировка началась!";
    }
}
