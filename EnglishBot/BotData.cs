using System;

namespace EnglishBot
{
    public static class BotData
    {
        public static readonly string BotToken = "1522714521:AAEZnwVYe1dG8MEcUUv4VYoRuPu_r60YNZw";

        public enum eStatus
        {
            Empty,
            Adding,
            AddingRussian,
            AddingEnglish,
            AddingSubject,
            Deleting,
            DeletingEnglish,
            Training,
            TrainingType,
            TrainingDirection,
            TrainingOnGoing,
            Stopping
        }
    }
}
