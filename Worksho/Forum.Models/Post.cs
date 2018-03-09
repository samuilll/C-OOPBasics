using System;
using System.Collections.Generic;

namespace Forum.Models
{
    public class Post
    {


        public Post(int id, string title, string content, int categoryId, int authorId, IEnumerable<int> replies)
        {
            this.Id = id;
            this.Title = title;
            this.Content = content;
            this.CategoryId = categoryId;
            this.AuthorId = authorId;
            this.Replies = new List<int>(replies);
        }

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string content;

        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        private int categoryId;

        public int CategoryId
        {
            get { return categoryId; }
            set { categoryId = value; }
        }

        private int authorId;

        public int AuthorId
        {
            get { return authorId; }
            set { authorId = value; }
        }

        private ICollection<int> replies;

        public ICollection<int> Replies
        {
            get { return replies; }
            set { replies = value; }
        }






    }
}
