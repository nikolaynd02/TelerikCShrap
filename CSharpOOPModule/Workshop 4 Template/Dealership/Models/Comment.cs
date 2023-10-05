
using Dealership.Models.Contracts;
using System;

namespace Dealership.Models
{
    public class Comment : IComment
    {
        public const int CommentMinLength = 3;
        public const int CommentMaxLength = 200;
        public const string InvalidCommentError = "Content must be between 3 and 200 characters long!";

        private string content;
        private string author;
        public Comment(string content, string author)
        {
            Content = content;
            Author = author;
        }

        public string Content
        {
            get { return content; }
            private set
            {
                Validator.ValidateIntRange(value.Length, CommentMinLength, CommentMaxLength, InvalidCommentError);
                content = value;
            }
        }

        public string Author
        {
            get { return author; }
            private set
            {
                //We should have some constrant to check for author length
                author = value;
            }
        }

        
    }
}
