using Hillerød_Sejlklub.Models;
using Hillerød_Sejlklub.Repository.Blog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hillerød_Sejlklub.Pages.Blog;

public class CreateBlogModel : PageModel
{
    private readonly IRepositoryBlogs _repo;

    [BindProperty]
    public BlogPost NewPost { get; set; } = new();

    public CreateBlogModel(IRepositoryBlogs repo)
    {
        _repo = repo;
    }

    public void OnGet() { }

    public IActionResult OnPost()
    {
        NewPost.PublishedDate = DateTime.Now;
        _repo.Add(NewPost);
        return RedirectToPage("/Blog/BlogPage");
    }
}
