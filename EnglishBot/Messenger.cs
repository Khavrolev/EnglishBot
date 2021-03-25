using System;
using System.Threading.Tasks;
using Telegram.Bot;

namespace EnglishBot
{
    public class Messenger
    {
        private CommandParser parser;
        private ITelegramBotClient botClient;

        public Messenger(ITelegramBotClient botClient)
        {
            parser = new CommandParser();
            this.botClient = botClient;
        }

        public async Task MakeAnswer(Conversation chat)
        {
            var lastmessage = chat.LastMessage;
            ChatStatus chatStatus = chat.Status;

            if (parser.IsMessageCommand(lastmessage))
            {
                if (chatStatus.isEmpty() || parser.IsStopCommand(lastmessage))
                    await ExecCommand(chat, lastmessage);
                else
                    await SendText(chat, "Команду подать сейчас нельзя, осуществляется другая операция");
            }
            else if (chatStatus.isAdding())
            {
                var text = "";

                if (chat.FillWord(lastmessage) == 0)
                    text = chat.ChangeStatus();
                else
                    text = "Данные введены некорректно, повторите";

                await SendText(chat, text);
            }
            else if (chatStatus.isDeleting())
            {
                var text = "";

                if (chat.DeleteWord(lastmessage) == 0)
                    text = chat.ChangeStatus();
                else
                    text = "Слово не найдено или введено некорректно, повторите";

                await SendText(chat, text);
            }
            else if (chatStatus.isTraining())
            {
                var text = "";

                if (chat.TrainingProcess(lastmessage) == 0)
                    text = chat.ChangeStatus();
                else
                    text = "Данные введены некорректно, повторите";

                await SendText(chat, text);
            }
            else
            {
                var text = "Такой команды нет, повторите";
                await SendText(chat, text);
            }
        }

        private async Task SendText(Conversation chat, string text)
        {
            await botClient.SendTextMessageAsync(
            chatId: chat.GetId(), text: text);
        }

        private async Task ExecCommand(Conversation chat, string text)
        {
            if (parser.IsTextCommand(text))
            {
                IChatTextCommand command = (IChatTextCommand)parser.GetCommand(text);
                chat.Status.status = command.ReturnStatus();
                await SendText(chat, chat.ChangeStatus());
            }
        }
    }
}
