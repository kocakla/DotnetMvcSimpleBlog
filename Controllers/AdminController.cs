using DotNet_mvcBlog.Context;
using DotNet_mvcBlog.Models;
using DotNet_mvcBlog.Models.ViewModels;
using DotNet_mvcBlog.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace DotNet_mvcBlog.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly BlogDbContext _context;
        private readonly UserManager<BlogIdentityUser> _userManager;
        private readonly SignInManager<BlogIdentityUser> _signInManager;
        public AdminController(BlogDbContext context, UserManager<BlogIdentityUser> userManager, SignInManager<BlogIdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new BlogIdentityUser
            {
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Email,
                UserName = model.Email,
            };
            if (model.Password != model.RePassword)
            {
                ModelState.AddModelError("", "Do not match passwords.");
                return View(model);
            }
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                // Kullanıcıya "Admin" rolünü ver
                var roleResult = await _userManager.AddToRoleAsync(user, "Admin");

                if (!roleResult.Succeeded)
                {
                    foreach (var error in roleResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(model);
                }
                else
                {
                    ModelState.AddModelError("", "Role assigned."); // Debug için görünür
                }
                // Giriş yap
                await _signInManager.SignInAsync(user, isPersistent: false);

                // Yönlendir
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                // Hataları modele ekle
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);

            }

        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {


            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password.");
                return View(model);
            }

            // Eğer e-posta onayı gerekiyorsa burayı ekle
            /* if (!await _userManager.IsEmailConfirmedAsync(user))
            {
                ModelState.AddModelError(string.Empty, "Lütfen e-posta adresinizi onaylayın.");
                return View(model);
            } */

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {

                return RedirectToAction("Index", "Admin"); // Default yönlendirme
            }

            ModelState.AddModelError(string.Empty, "Invalid email or password.");
            return View(model);
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            var blogs = _context.Blogs.ToList();
            return View(blogs);
        }
        [AllowAnonymous]
        public IActionResult EditBlog(int id)
        {
            var blog = _context.Blogs.Where(x => x.Id == id).FirstOrDefault();
            if (blog == null)
            {
                return NotFound(); // veya View("Error") ya da bir hata sayfası yönlendirmesi
            }
            return View(blog);
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult EditBlog(Blog model)
        {
            var blog = _context.Blogs.Where(x => x.Id == model.Id).FirstOrDefault();
            blog.Name = model.Name;
            blog.Text = model.Text;
            blog.Tags = model.Tags;
            blog.ImageUrl = model.ImageUrl;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [AllowAnonymous]
        public IActionResult ToggleStatus(int id)
        {
            var blog = _context.Blogs.Where(x => x.Id == id).FirstOrDefault();
            if (blog.Status == true)
            {
                blog.Status = false;
            }
            else
            {
                blog.Status = true;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [AllowAnonymous]
        public IActionResult DeleteBlog(int id)
        {
            var blog = _context.Blogs.Where(x => x.Id == id).FirstOrDefault();
            _context.Blogs.Remove(blog);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [AllowAnonymous]
        public IActionResult CreateBlog()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateBlog(Blog model)
        {
            if (ModelState.IsValid)
            {
                model.PublishDate = DateTime.Now;
                model.Status = true;

                _context.Blogs.Add(model);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            // Model geçerli değilse formu tekrar göster
            return View(model);
        }

    }
}