using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishBot
{
    public class ChatStatus
    {
        public BotData.eStatus status;

        public ChatStatus()
        {
            status = BotData.eStatus.Empty;
        }

        public bool isAdding()
        {
            return (status == BotData.eStatus.AddingRussian ||
                    status == BotData.eStatus.AddingEnglish ||
                    status == BotData.eStatus.AddingSubject);
        }

        public bool isDeleting()
        {
            return (status == BotData.eStatus.DeletingEnglish);
        }

        public bool isEmpty()
        {
            return (status == BotData.eStatus.Empty);
        }

        public bool isTraining()
        {
            return (status == BotData.eStatus.TrainingDirection ||
                    status == BotData.eStatus.TrainingType ||
                    status == BotData.eStatus.TrainingOnGoing);
        }
    }
}
