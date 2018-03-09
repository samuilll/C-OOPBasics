using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Models
{
  public  class User
    {

        public User(int id, string userName, string password, IEnumerable<int> posts)
        {
            this.Id = id;
            this.UserName = userName;
            this.Password = password;
            this.Posts = new List<int>(posts);
        }
        public User(int id, string userName, string password)
        {
            this.Id = id;
            this.UserName = userName;
            this.Password = password;
            this.Posts = new List<int>();
        }

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string username;

        public string UserName
        {
            get { return username; }
            set { username = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private ICollection<int> posts;

        public ICollection<int> Posts
        {
            get { return posts; }
            set { posts = value; }
        }
    }
}
