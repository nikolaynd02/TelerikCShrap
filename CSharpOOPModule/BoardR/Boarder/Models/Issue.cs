using System;

namespace Boarder.Models
{
    public class Issue : BoardItem
    {
        public Issue(string title, string description, DateTime dueDate)
            : base(title, dueDate, Status.Open)
        {
            this.Description = description ?? "No desciption";

            this.AddEventLog($"Created Issue: {this.ViewInfo()}. Description: {this.Description}");
        }

        public string Description { get; }

        public override void AdvanceStatus()
        {
            if(Status != Status.Verified)
            {
                Status = Status.Verified;

                AddEventLog($"Issue status changed from Open to Verified");
            }
            else
            {
                AddEventLog($"Issue can't advance, already at Verified");
            }
        }
        public override void RevertStatus()
        {
            if(Status != Status.Open)
            {
                Status = Status.Open;

                AddEventLog($"Issue status changed from Verified to Open");
            }
            else
            {
                AddEventLog($"Issue can't revert, already at Open");
            }
        }
    }
}
