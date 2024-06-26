using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_V2
{
    public class EventLog : UIWindow
    {
        private string[] eventMessages; //list of messages in the event log

        /// <summary>
        /// Constructor method for the Event Log UI object 
        /// </summary>
        public EventLog() : base(GlobalVariables.EventLogWindowWidth, GlobalVariables.EventLogWindowHeight)
        {
            eventMessages = new string[GlobalVariables.maxEventLogMessage];
        }

        /// <summary>
        /// Mutator method to add event messages to the event log window
        /// </summary>
        /// <param name="eventMessage">The message to be added to the event log</param>
        public void AddEvent(string eventMessage)
        {
            if (eventMessage != null && eventMessage.Length < GlobalVariables.EventLogWindowWidth -3)
            {
                base.ClearContents();//clears previous content in the window

                //shift messages position in the queue
                for (int i=1; i<eventMessages.Length; i++)
                {
                    eventMessages[i - 1] = eventMessages[i];
                }

                //adds message to the end of queue
                eventMessages[eventMessages.Length -1] = eventMessage;

                //display messages in the window
                for (int i=0; i<eventMessages.Length; i++)
                {
                    if (eventMessages[i] != null)
                    {
                        AddLine(i+1, "> " + eventMessages[i]);
                    }
                }
            }
        }
    }
}
