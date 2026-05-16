using System;

namespace ex23.entities
{
    class Comment
    {
        public string Text { get; set; }

        public Comment()
        {
            Text = string.Empty;
        }

        public Comment(string text)
        {
            Text = text ?? string.Empty;
        }
    }
}