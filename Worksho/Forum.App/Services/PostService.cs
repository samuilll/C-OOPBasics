using Forum.App.UserInterface.ViewModels;
using Forum.Data;
using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forum.App.Services
{
    public static class PostService
    {
        internal static Category GetCategory(int categoryId)
        {
            ForumData forumData = new ForumData();

            Category category = forumData.Categories.Find(c => c.Id == categoryId);

            return category;
        }
        internal static IList<ReplyViewModel> GetPostReplies(int postId)
        {
            ForumData forumData = new ForumData();

            Post post = forumData.Posts.Find(p => p.Id == postId);

            IList<ReplyViewModel> replies = new List<ReplyViewModel>();

            foreach (var replyId in post.Replies)
            {
                var reply = forumData.Replies.Find(r => r.Id == replyId);
                replies.Add(new ReplyViewModel(reply));
            }

            return replies;
        }

        internal static string[] GetAllCategoryNames()
        {
            ForumData forumData = new ForumData();

            var allCategories = forumData.Categories.Select(c => c.Name).ToArray();

            return allCategories;
        }

        public static bool TrySaveReply(ReplyViewModel replyViewModel,int postId)
        {
            if (!replyViewModel.Content.Any())
            {
                return false;
            }

            var forumData = new ForumData();
            var post = forumData.Posts.Single(p=>p.Id==postId);
            var author = UserService.GetUser(replyViewModel.Author, forumData);
            var replyId = forumData.Replies.LastOrDefault()?.Id + 1 ?? 1;
            var content = string.Join("",replyViewModel.Content);
            var reply = new Reply(replyId,content,author.Id,postId);

            forumData.Replies.Add(reply);
            post.Replies.Add(replyId);
            forumData.SaveChanges();
           
            return true;
        }

        public static IEnumerable<Post> GetPostsByCategory(int categoryId)
        {
            ForumData forumData = new ForumData();

            var postIds = forumData.Categories.First(c => c.Id == categoryId).Posts;

            IEnumerable<Post> posts = forumData.Posts.Where(p => postIds.Contains(p.Id));

            return posts;
        }

        public static PostViewModel GetPostViewModel(int postId)
        {
            ForumData forumData = new ForumData();

            Post post = forumData.Posts.Find(p => p.Id == postId);

            PostViewModel pvm = new PostViewModel(post);

            return pvm;
        }

        private static Category EnsureCategory(PostViewModel postView, ForumData forumData)
        {
            var categoryName = postView.Category;
            Category category = forumData.Categories.FirstOrDefault(x => x.Name == categoryName);
            if (category == null)
            {
                var categories = forumData.Categories;
                int categoryId = categories.Any() ? categories.Last().Id + 1 : 1;
                category = new Category(categoryId, categoryName, new List<int>());
                forumData.Categories.Add(category);
            }
            return category;
        }

        public static bool TrysavePost(PostViewModel postViewModel)
        {
            bool emptyCategory = string.IsNullOrWhiteSpace(postViewModel.Category);
            bool emptyTitle = string.IsNullOrWhiteSpace(postViewModel.Title);
            bool emptyContent = !postViewModel.Content.Any();

            if (emptyCategory || emptyTitle || emptyContent)
            {
                return false;
            }
            ForumData forumData = new ForumData();
            Category category = EnsureCategory(postViewModel, forumData);

            var postId = forumData.Posts.Any() ? forumData.Posts.Last().Id + 1 : 1;
            var author = UserService.GetUser(postViewModel.Author, forumData);
            var content = string.Join("", postViewModel.Content);
            var post = new Post(postId, postViewModel.Title, content, category.Id, author.Id, new List<int>());

            forumData.Posts.Add(post);
            category.Posts.Add(postId);
            author.Posts.Add(postId);
            forumData.SaveChanges();

            postViewModel.PostId = postId;

            return true;
        }
    }
}
