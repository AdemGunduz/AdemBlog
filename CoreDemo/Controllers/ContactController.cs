using BusinessLayer.Concrete;
using DataAccessLayer.EntitiyFramwork;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CoreDemo.Controllers
{
	public class ContactController : Controller
	{
		ContactManager cm = new ContactManager(new EfContactRepository());
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(Contact p)
		{
			p.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			p.ContactStatus = true;
			cm.ContactAdd(p);
			return RedirectToAction("Index", "Blog"); ;
		}
	}
}
