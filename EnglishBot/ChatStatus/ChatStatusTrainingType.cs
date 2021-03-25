using System;

namespace EnglishBot
{
    public class ChatStatusTrainingType: ChatStatusDesc
    {
        public override BotData.eStatus GetNextStatus() => BotData.eStatus.TrainingDirection;
        public override string GetResponce() => "Выберете направление, напишите русанг или ангрус";
    }
}
