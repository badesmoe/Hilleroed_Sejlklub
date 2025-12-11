using Hillerød_Sejlklub.Models;

namespace Hillerød_Sejlklub.Repository.Blog
{
    public interface IRepositoryBlogs
    {
        void Add(BlogPost blogPost);
        List<BlogPost> GetBlogs();
        BlogPost? Search(int id);
        void Delete(int id);

    }
}