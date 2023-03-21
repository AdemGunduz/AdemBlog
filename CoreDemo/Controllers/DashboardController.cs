using BusinessLayer.Concrete;
using DataAccessLayer.EntitiyFramwork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class DashboardController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
    }
}
