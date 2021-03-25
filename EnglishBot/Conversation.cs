using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Telegram.Bot.Types;

namespace EnglishBot
{
    public class Conversation
    {
        private Chat telegramChat;
        public string LastMessage { get; set; }
        //тут бы запилил сериализацию в json и чтение/запись в файл
        private List<Word> words;
        private string deletedWord;
        private bool bAdding;
        public ChatStatus Status { get; set; }
        public Training Train { get; set; }

        public Conversation(Chat chat)
        {
            Status = new ChatStatus();
            telegramChat = chat;
            words = new List<Word>();
            bAdding = false;
            Train = new Training();
        }

        public long GetId() => telegramChat.Id;

        public string ChangeStatus()
        {
            ChatStatusDesc chatStatusDesc;

            switch (Status.status)
            {
                case (BotData.eStatus.Adding):
                    chatStatusDesc = new ChatStatusAdding();
                    words.Add(new Word());
                    bAdding = true;
                    break;
                case (BotData.eStatus.AddingRussian):
                    chatStatusDesc = new ChatStatusAddingRussian();
                    break;
                case (BotData.eStatus.AddingEnglish):
                    chatStatusDesc = new ChatStatusAddingEnglish();
                    break;
                case (BotData.eStatus.AddingSubject):
                    chatStatusDesc = new ChatStatusAddingSubject(words[words.Count - 1].English);
                    bAdding = false;
                    break;
                case (BotData.eStatus.Deleting):
                    chatStatusDesc = new ChatStatusDeleting();
                    break;
                case (BotData.eStatus.DeletingEnglish):
                    chatStatusDesc = new ChatStatusDeletingEnglish(deletedWord);
                    break;
                case (BotData.eStatus.Training):
                    chatStatusDesc = new ChatStatusTraining();
                    Train.bOnGoing = true;
                    Train.words = words;
                    break;
                case (BotData.eStatus.TrainingType):
                    chatStatusDesc = new ChatStatusTrainingType();
                    break;
                case (BotData.eStatus.TrainingDirection):
                    chatStatusDesc = new ChatStatusTrainingDirection();
                    break;
                case (BotData.eStatus.TrainingOnGoing):
                    chatStatusDesc = new ChatStatusTrainingOnGoing();
                    break;
                case (BotData.eStatus.Stopping):
                    chatStatusDesc = new ChatStatusStopping();
                    if (Train.bOnGoing)
                        Train.Clear();
                    if (bAdding)
                        DeleteLastWord();
                    break;
                default:
                    chatStatusDesc = null;
                    break;
            }

            if (chatStatusDesc != null)
            {
                Status.status = chatStatusDesc.GetNextStatus();
                return chatStatusDesc.GetResponce();
            }
            else
            {
                Status.status = BotData.eStatus.Empty;
                return "Неверный статус";
            }
        }

        public void AddWord()
        {
            words.Add(new Word());
        }

        private void DeleteLastWord()
        {
            if (words.Count > 0)
                words.Remove(words[words.Count - 1]);
        }

        public int FillWord(string text)
        {
            Word word = words[words.Count - 1];
            //было бы время, запилить бы проверку на повторение слов на русском и английском
            switch (Status.status)
            {
                case (BotData.eStatus.AddingRussian):
                    return word.AddRussian(text);
                case (BotData.eStatus.AddingEnglish):
                    return word.AddEnglish(text);
                case (BotData.eStatus.AddingSubject):
                    return word.AddSubject(text);
            }

            return -1;
        }

        public int TrainingProcess(string text)
        {
            //было бы время, запилить бы проверку на повторение слов на русском и английском
            switch (Status.status)
            {
                case (BotData.eStatus.TrainingType):
                    return Train.AddType(text);
                case (BotData.eStatus.TrainingDirection):
                    return Train.AddDirection(text);
                case (BotData.eStatus.TrainingOnGoing):
                    return Train.CheckAnswer(text);
            }

            return -1;
        }

        public int DeleteWord(string text)
        {
            if (!Regex.IsMatch(text, "[a-zA-Z]") || text.Contains(' '))
                return -1;

            Word word = GetEnglishIndex(text);

            if (word != null)
            {
                deletedWord = word.English;
                words.Remove(word);
                return 0;
            }

            return -1;
        }

        private Word GetEnglishIndex(string text)
        {
            for (int i = 0; i < words.Count; i++)
            {
                if (words[i].English == text)
                    return words[i];
            }

            return null;
        }
    }
}
