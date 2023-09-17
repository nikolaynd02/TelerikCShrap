using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    internal class EventLog
    {
        private string description;
        private DateTime time;

        public EventLog(string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                throw new ArgumentNullException("Value cannot be null.");
            }
            this.description = description;
            this.time = DateTime.Now;
        }

        public string Description 
        {
            get
            {
                return this.description;
            }            
        }

        public DateTime Time 
        {
            get
            {
                return this.time;
            } 
        }

        public string ViewInfo()
        {
            return $"[{time.ToString()}] {description}";
        }
    }
}
