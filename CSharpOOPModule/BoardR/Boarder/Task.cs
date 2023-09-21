using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boarder
{
    internal class Task : BoardItem
    {
        private string assignee;

        public Task(string title, string assignee, DateTime dueDate) : base(title, dueDate)
        {
            if (string.IsNullOrEmpty(assignee))
            {
                throw new ArgumentNullException("Assignee can not be null or empty");
            }
            if (assignee.Length < 5 || assignee.Length > 30)
            {
                throw new ArgumentException("Assignee should have length between 5 and 30 symbols.");
            }

            this.assignee = assignee;

            Status = Status.ToDo;

            AddEventLog($"Created Task: '{title}', [{Status}|{dueDate.ToString("dd-MM-yyyy")}]");
        }

        public string Assignee
        {
            get { return assignee; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Assignee can not be null or empty");
                }
                if (value.Length < 5 || value.Length > 30)
                {
                    throw new ArgumentException("Assignee should have length between 5 and 30 symbols.");
                }

                AddEventLog($"Assignee changed from {assignee} to {value}");

                assignee = value;
            }
        }
    }
}
