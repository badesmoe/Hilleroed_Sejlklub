using Hillerød_Sejlklub.Models;
using Hillerød_Sejlklub.Repository.Blog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hillerød_Sejlklub.Pages.Blog
{
    public class UsersBlogModel : PageModel
    {
        private readonly IRepositoryBlogs _repo;

        public List<BlogPost> BlogPosts { get; set; } = new();

        public UsersBlogModel(IRepositoryBlogs repo)
        {
            _repo = repo;
        }

        public void OnGet()
        {
            BlogPosts = _repo.GetBlogs();
        }
    }
}
