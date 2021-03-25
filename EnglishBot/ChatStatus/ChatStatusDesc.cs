using System;

namespace EnglishBot
{
    public abstract class ChatStatusDesc
    {
        public string Text { get; }

        public ChatStatusDesc(string text = "")
        {
            Text = text;
        }

        public abstract BotData.eStatus GetNextStatus();
        public abstract string GetResponce();
    }
}
