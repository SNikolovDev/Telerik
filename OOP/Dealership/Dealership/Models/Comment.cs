using Dealership.Models.Contracts;

namespace Dealership.Models
{
    public class Comment : IComment
    {
        public const int CommentMinLength = 3;
        public const int CommentMaxLength = 200;
        public const string InvalidCommentError = "Content must be between 3 and 200 characters long!";

        private string content;

        public Comment(string content, string author)
        {
            this.Content = content;
            this.Author = author;
        }

        public string Content
        {
            get => this.content;
            private set
            {
                Validator.ValidateIntRange(value.Length, CommentMinLength, CommentMaxLength, InvalidCommentError);

                this.content = value;
            }
        }

        public string Author { get; set; }
    }
}
