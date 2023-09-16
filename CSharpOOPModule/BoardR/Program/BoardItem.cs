using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    internal class BoardItem
    {
        public string title;
        public DateTime dueDate;
        public Status status;

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


            this.status = Status.Open;
        }

        public void RevertStatus()
        {
            if(status != initialStatus)
            {
                status--;
            }

        }

        public void AdvanceStatus()
        {
            if (status != finalStatus)
            {
                status++;
            }

        }

        public string ViewInfo()
        {
            return $"{title} , [{status}|{dueDate.ToString("dd-MM-yyyy")}]";
        }
    }
}
