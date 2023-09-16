using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum
{
    internal class ForumPost
    {
        public string author;
        public string text;
        public int upvotes;
        public List<string> replies;

        public ForumPost(string author, string text, int upvotes = 0)
        {
            this.author = author;
            this.text = text;
            this.upvotes = upvotes;
            replies = new List<string>();
        }

        public string Format()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"{text} / by {author}, {upvotes} upvotes");

            if(replies.Count == 0)
            {
                output.AppendLine("* There are no replies.* ");
                return output.ToString();
            }


            foreach(string rep in replies)
            {
                output.AppendLine(" - " + rep);                
            }

            return output.ToString();
        }
    }
}
