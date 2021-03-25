using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace EnglishBot
{
    public class BotMessageLogic
    {
        private Messenger messenger;
        private Dictionary<long, Conversation> chatList;

        public BotMessageLogic(ITelegramBotClient botClient)
        {
            messenger = new Messenger(botClient);
            chatList = new Dictionary<long, Conversation>();
        }

        private Conversation ReturnChat(Chat chat)
        {
            if (!chatList.ContainsKey(chat.Id))
            {
                var newchat = new Conversation(chat);

                chatList.Add(chat.Id, newchat);
            }

            return chatList[chat.Id];
        }

        public async Task Response(MessageEventArgs e)
        {
            var chat = ReturnChat(e.Message.Chat);
            chat.LastMessage = e.Message.Text;

            await messenger.MakeAnswer(chat);
        }
    }
}
