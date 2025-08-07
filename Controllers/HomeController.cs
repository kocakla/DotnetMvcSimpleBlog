using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DotNet_mvcBlog.Models;
using DotNet_mvcBlog.Context;

namespace DotNet_mvcBlog.Controllers;

public class HomeController : Controller
{
   
      private readonly BlogDbContext _context;

         public HomeController(BlogDbContext context)
        {
            _context = context;
            
        }

    public IActionResult Index()
    {
        ViewBag.HeaderTitle = "Blog Title";
        ViewBag.HeaderSubtitle = "Blog Tags";
        var blogs = _context.Blogs.Where(x => x.Status == true).ToList();
        return View(blogs);
    }

    public IActionResult Privacy()
    {
        ViewBag.HeaderTitle = "Privacy";
        ViewBag.HeaderSubtitle = "Rules...";

        return View();
    }
    public IActionResult About()
    {
        ViewBag.HeaderTitle = "About";
        ViewBag.HeaderSubtitle = "Who we are...";

        return View();
    }
    public IActionResult Contact()
    {
        ViewBag.HeaderTitle = "Contact";
        ViewBag.HeaderSubtitle = "Send us your message";
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
