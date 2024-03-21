using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_V2
{
    public class EventLog : UIWindow
    {
        private string[] eventMessages;

        public EventLog() : base(GlobalVariables.EventLogWindowWidth, GlobalVariables.EventLogWindowHeight)
        {
            eventMessages = new string[GlobalVariables.maxEventLogMessage];
        }

        public void AddEvent(string eventMessage)
        {
            if (eventMessage.Length < GlobalVariables.EventLogWindowWidth -3)
            {
                base.ClearContents();

                for (int i=1; i<eventMessage.Length-1; i++)
                {
                    eventMessages[i - 1] = eventMessages[i];
                }

                eventMessages[eventMessages.Length -1] = eventMessage;

                for (int i=0; i<eventMessages.Length; i++)
                {
                    AddLine(i, "> " + eventMessages[i]);
                }
            }
        }
    }
}
