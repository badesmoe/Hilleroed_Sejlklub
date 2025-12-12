using System.Collections.Generic;
using Hillerød_Sejlklub.Models;

namespace Hillerød_Sejlklub.Repository.Blog
{
    public class Blogs : IRepositoryBlogs
    {
        private readonly List<BlogPost> blogs = new List<BlogPost>();

        public void Add(BlogPost blog)
        {
            blogs.Add(blog);
        }

        public void Delete(int id)
        {
            for (int i = 0; i < blogs.Count; i++)
            {
                if (blogs[i].Id == id)
                {
                    blogs.RemoveAt(i);
                    return;
                }
            }
        }

        public List<BlogPost> GetBlogs()
        {
            return blogs;
        }

        public BlogPost? Search(int id)
        {
            foreach (BlogPost blog in blogs)
            {
                if (id == blog.Id)
                {
                    return blog;
                }
            }
            return null;
        }
    }
}
