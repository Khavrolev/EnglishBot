using System;
using System.Collections.Generic;

namespace EnglishBot
{
    public class CommandParser
    {
        private List<IChatCommand> Command;

        public CommandParser()
        {
            Command = new List<IChatCommand>();
            AddCommands();
        }

        public void AddCommands()
        {
            Command.Add(new AddWordCommand());
            Command.Add(new DeleteWordCommand());
            Command.Add(new StopCommand());
            Command.Add(new TrainCommand());
        }

        public IChatCommand GetCommand(string message)
        {
            return Command.Find(x => x.CheckMessage(message));
        }

        public bool IsMessageCommand(string message)
        {
            var command = GetCommand(message);

            return command is not null;
        }

        public bool IsStopCommand(string message)
        {
            var command = GetCommand(message);

            return command is StopCommand;
        }

        public bool IsTextCommand(string message)
        {
            var command = GetCommand(message);

            return command is IChatTextCommand;
        }
    }
}
