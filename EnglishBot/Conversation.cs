using System;
using System.Collections.Generic;
using Telegram.Bot.Types;

namespace EnglishBot
{
    public class Conversation
    {
        private Chat telegramChat;
        private List<Message> telegramMessages;
        public BotData.eStatus Status { get; set; }
        public Conversation(Chat chat)
        {
            Status = BotData.eStatus.Empty;
            telegramChat = chat;
            telegramMessages = new List<Message>();
        }

        public void AddMessage(Message message)
        {
            telegramMessages.Add(message);
        }

        //public List<string> GetTextMessages()
        //{
        //    var textMessages = new List<string>();

        //    foreach (var message in telegramMessages)
        //    {
        //        if (message.Text != null)
        //        {
        //            textMessages.Add(message.Text);
        //        }
        //    }

        //    return textMessages;
        //}

        public long GetId() => telegramChat.Id;

        public string GetLastMessage() => telegramMessages[telegramMessages.Count - 1].Text;
    }
}
