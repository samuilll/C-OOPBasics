using Forum.App.Controllers;
using Forum.Data;
using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Forum.App.Controllers.SignUpController;

namespace Forum.App.Services
{
   public static class UserService
    {
        public static object ForumData { get; private set; }

        public static bool TryLogInUser(string username, string password)
        {
            if (string.IsNullOrEmpty(username)|| string.IsNullOrEmpty(password))
            {
                return false;
            }

            ForumData forumdata = new ForumData();

            bool userExist = forumdata.Users.Any(u => u.Username == username && u.Password == password);

            return userExist;
        }

        public static SignUpStatus TrySignUpUser(string username, string password)
        {
            bool validUserName = !string.IsNullOrWhiteSpace(username) && username.Length > 3;
            bool validPassword = !string.IsNullOrWhiteSpace(password) && password.Length > 3;

            if (!validPassword||!validUserName)
            {
                return SignUpStatus.DetailsError;
            }

            ForumData forumData = new ForumData();

            bool userAlreadyExist = forumData.Users.Any(u => u.Username == username);

            if (!userAlreadyExist)
            {
                int userId = forumData.Users.LastOrDefault()?.Id + 1 ?? 1;
                User user = new User(userId, username, password,new List<int>());
                forumData.Users.Add(user);
                forumData.SaveChanges();
                return SignUpStatus.Success;
            }

            return SignUpStatus.UsernameTakenError;
        }

        public static User GetUser(int userId)
        {
            ForumData forumData = new ForumData();

            User user = forumData.Users.Find(u => u.Id == userId);

            return user;
        }

        public static User GetUser(string userName,ForumData forumData)
        {
            User user = forumData.Users.Find(u => u.Username == userName);

            return user;
        }
    }

    
}
