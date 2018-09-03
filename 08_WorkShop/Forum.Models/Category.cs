using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Models
{
   public class Category
    {
        public Category(int id, string name, IEnumerable<int> posts)
        {
            this.Id = id;
            this.Name = name;
            this.Posts = new List<int>(posts);
        }

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private ICollection<int> posts;


        public ICollection<int> Posts
        {
            get { return posts; }
            set { posts = value; }
        }

    }
}
