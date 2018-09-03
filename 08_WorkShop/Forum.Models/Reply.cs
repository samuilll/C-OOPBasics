using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Models
{
  public  class Reply
    {

        public Reply(int id, string content, int authorId, int postId)
        {
            this.Id = id;
            this.Content = content;
            this.AuthorId = authorId;
            this.PostId = postId;
        }

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string content;

        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        private int authorId;

        public int AuthorId
        {
            get { return authorId; }
            set { authorId = value; }
        }

        private int postId;

        public int PostId
        {
            get { return postId; }
            set { postId = value; }
        }
    }
}
