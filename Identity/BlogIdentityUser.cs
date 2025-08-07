using Microsoft.AspNetCore.Identity;

namespace DotNet_mvcBlog.Identity
{
    public class BlogIdentityUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}