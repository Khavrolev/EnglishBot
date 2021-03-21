using System;

namespace EnglishBot
{
    public interface IChatCommand
    {
        bool CheckMessage(string message);
    }
}
