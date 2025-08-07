
using Microsoft.AspNetCore.Mvc;
using DotNet_mvcBlog.Context;

namespace DotNet_mvcBlog.Controllers
{
    public class BlogController : Controller
    {
        private readonly BlogDbContext _context;

        public BlogController(BlogDbContext context)
        {
            _context = context;

        }
        public IActionResult Blog(int id)
        {
            var blog = _context.Blogs.Where(x => x.Id == id).FirstOrDefault();

            ViewBag.HeaderTitle = blog.Name;
            ViewBag.HeaderSubtitle = blog.Tags;

            return View(blog);
        }
    
    }
}