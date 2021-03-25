using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishBot
{
    public class Training
    {
        public string Type { get; set; }
        public string Direction { get; set; }
        public bool bOnGoing;
        public List<Word> words;

        public Training()
        {
            Clear();
        }

        public void Clear()
        {
            Type = "";
            Direction = "";
            bOnGoing = false;
        }

        //Было бы время, сделал бы инлайны на добавление типа и направления, запилил бы проверку на то, что "все" или есть такая тематика в массиве слов
        public int AddType(string text)
        {
            Type = text;
            return 0;
        }

        //Было бы время, сделал бы инлайны на добавление типа и направления
        public int AddDirection(string text)
        {
            if(text == "русанг" || text == "ангрус")
            {
                Direction = text;
                return 0;
            }
            {
                Direction = "";
                return -1;
            }
        }

        //Было бы время, сделал бы проверку и вывод ошибки в текст
        public int CheckAnswer(string text)
        {
            return 0;
        }
    }
}
