using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    internal class Issue : BoardItem
    {
        private string description;

        public Issue(string title, string description, DateTime dueDate) : base(title, dueDate)
        {
            this.Description = description;

            history.Add(new EventLog($"Created Issue: '{title}', [{Status}|{dueDate.ToString("dd-MM-yyyy")}]. Description: {description}"));

        }

        public string Description
        {
            get { return description; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    description = "No description";
                }
                else
                {
                    description = value;
                }
            } 
        }
    }
}
