using Microsoft.EntityFrameworkCore;
using DotNet_mvcBlog.Models;
namespace DotNet_mvcBlog.Context
{
    public class BlogDbContext : DbContext
    {
         public BlogDbContext(DbContextOptions<BlogDbContext> options)
            : base(options)
        {
        }
        public DbSet<Blog> Blogs { get; set; }
    }
}