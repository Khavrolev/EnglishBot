using System;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace EnglishBot
{
    [DataContract]
    public class Word
    {
        [DataMember]
        public string Russian { get; set; }
        [DataMember]
        public string English { get; set; }
        [DataMember]
        public string Subject { get; set; }

        public int AddRussian(string text)
        {
            if (Regex.IsMatch(text, "^[А-Яа-я]+$") && !text.Contains(' '))
            {
                Russian = text;
                return 0;
            }
            else
                return -1;
        }

        public int AddEnglish(string text)
        {
            if (Regex.IsMatch(text, "[a-zA-Z]") && !text.Contains(' '))
            {
                English = text;
                return 0;
            }
            else
                return -1;
        }

        public int AddSubject(string text)
        {
            if (Regex.IsMatch(text, "^[А-Яа-я]+$") && !text.Contains(' '))
            {
                Subject = text;
                return 0;
            }
            else
                return -1;
        }
    }
}
