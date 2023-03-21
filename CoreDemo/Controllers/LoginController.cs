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

		public async  Task<IActionResult> Index(Writer p)
		{
			MyConnectionDbContext c = new MyConnectionDbContext();
			var datavalues = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);
			if (datavalues != null)
			{
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name,p.WriterMail)
				};
				var useridentity = new ClaimsIdentity(claims ,"a");
				ClaimsPrincipal principal= new ClaimsPrincipal(useridentity);
				await HttpContext.SignInAsync(principal);
				return RedirectToAction("Index", "Writer");

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
