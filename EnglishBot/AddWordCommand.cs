using System;

namespace EnglishBot
{
    public class AddWordCommand : AbstractCommand, IChatTextCommand
    {
        public AddWordCommand()
        {
            CommandText = "/addword";
        }

        public string ReturnText()
        {
            return "Введите русское значение слова";
        }
    }
}
