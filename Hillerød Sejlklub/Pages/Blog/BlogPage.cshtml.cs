using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hillerød_Sejlklub.Models;
using Hillerød_Sejlklub.Repository.Blog;

namespace Hillerød_Sejlklub.Pages.Blog
{
    public class IndexModel : PageModel
    {
        private readonly IRepositoryBlogs _blogPosts;

        public IndexModel(IRepositoryBlogs blogPosts) => _blogPosts = blogPosts;

        [BindProperty]
        public BlogPost NewPost { get; set; } = new();

        public List<BlogPost> BlogPosts { get; private set; } = new();

        public void OnGet()
        {
            BlogPosts = _blogPosts.GetBlogs();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                BlogPosts = _blogPosts.GetBlogs();
                return Page();
            }


            NewPost.PublishedDate = DateTime.Now;
            _blogPosts.Add(NewPost);


            return RedirectToPage();
        }
    }
}
