using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    internal class BoardItem
    {
        private string title;
        private DateTime dueDate;
        private Status status;
        private List<EventLog> history;

        private const Status initialStatus = Status.Open;
        private const Status finalStatus = Status.Verified;

        public BoardItem(string title, DateTime dueDate)
        {
            if(string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException("Title can not be null or empty");
            }

            if(title.Length < 5 || title.Length > 30)
            {
                throw new ArgumentException("Title must have length between 5 and 30.");
            }
            this.title = title;

            if(dueDate < DateTime.Now)
            {
                throw new ArgumentException("Date can not be in the past.");
            }
            this.dueDate = dueDate;

            this.history = new List<EventLog>();

            this.history.Add(new EventLog("Item created"));

            this.status = Status.Open;
        }

        public Status Status 
        { get
            {
                return this.status;
            }
        }

        public string Title 
        {
            get 
            {
                return this.title;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Title can not be null or empty");
                }

                if (value.Length < 5 || value.Length > 30)
                {
                    throw new ArgumentException("Title must have length between 5 and 30.");
                }

                this.history.Add(new EventLog($"Title changed from {this.title} to {value}"));
                this.title = value;
            }
        }

        public DateTime DueDate
        {
            get
            {
                return this.dueDate;
            }
            set
            {
                if (value < DateTime.Now)
                {
                    throw new ArgumentException("Date can not be in the past.");
                }
                this.history.Add(new EventLog($"DueDate changed from {this.dueDate} to {value}"));
                this.dueDate = value;
            }
        }
        

        public void RevertStatus()
        {
            if(status != initialStatus)
            {
                this.history.Add(new EventLog($"Status changed from {status} to {--status}"));

                //status--;

                return;
            }
            this.history.Add(new EventLog($"Can't revert, already Open"));
        }

        public void AdvanceStatus()
        {
            if (status != finalStatus)
            {
                this.history.Add(new EventLog($"Status changed from {status} to {++status}"));
                //status++;

                return;
            }

            this.history.Add(new EventLog($"Can't advance, already Verified"));
        }

        public string ViewInfo()
        {
            return $"{title} , [{status}|{dueDate.ToString("dd-MM-yyyy")}]";
        }

        public string ViewHistory()
        {
            StringBuilder output = new StringBuilder();

            foreach(EventLog el in history)
            {
                output.AppendLine(el.ViewInfo());
            }

            return output.ToString();
        }
    }
}
