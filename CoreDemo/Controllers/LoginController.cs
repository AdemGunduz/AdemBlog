using DataAccessLayer.concrete;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CoreDemo.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(User p)
        {
            MyConnectionDbContext c = new MyConnectionDbContext();
            var datavalues = c.Users.FirstOrDefault(x => x.UserMail == p.UserMail && x.UserPassword == p.UserPassword);
            if (datavalues != null)
            {
                if (datavalues.RoleId == 1)
                {
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,p.UserMail),
                    new Claim(ClaimTypes.Role, "Admin")
                };
                    var useridentity = new ClaimsIdentity(claims, "a");
                    ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                    await HttpContext.SignInAsync(principal);

                    return RedirectToAction("Index", "Admin");
                }
                if(datavalues.RoleId == 2)
                {
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,p.UserMail),
                    new Claim(ClaimTypes.Role, "Writer")
                };
                    var useridentity = new ClaimsIdentity(claims, "a");
                    ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                    await HttpContext.SignInAsync(principal);

                    return RedirectToAction("Test", "Writer");
                }
                return View();


            }
            else
            {
                return View();
            }


        }
    }
}
//MyConnectionDbContext c = new MyConnectionDbContext();
//var datavalues = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);
//if (datavalues != null)
//{
//	HttpContext.Session.SetString("username", p.WriterMail);
//	return RedirectToAction("Index", "Writer");

//}
//else
//{
//	return View();
//}
