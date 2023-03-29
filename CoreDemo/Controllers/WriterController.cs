using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemo.Models;
using DataAccessLayer.concrete;
using DataAccessLayer.EntitiyFramwork;
using EntityLayer.Concrate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace CoreDemo.Controllers
{
	public class WriterController : Controller
	{
		MyConnectionDbContext c = new MyConnectionDbContext();
		UserManager wm = new UserManager(new EfUserRepository());
		
		public IActionResult Index()
		{
			var usermail = User.Identity.Name;
			ViewBag.v = usermail;
			MyConnectionDbContext c = new MyConnectionDbContext();
			var writerName = c.Users.Where(x=>x.UserMail==usermail).Select(y=>y.UserName).FirstOrDefault(); 
			ViewBag.v2=writerName;
			return View();
		}
	
		public IActionResult WriterProfile()
		{
			return View();
		}
        

        public IActionResult WriterMail()

		{
			return View();
		}
       
        public IActionResult Test()
		{
            var usermail = User.Identity.Name;
            ViewBag.v = usermail;
            MyConnectionDbContext c = new MyConnectionDbContext();
            var writerName = c.Users.Where(x => x.UserMail == usermail).Select(y => y.UserName).FirstOrDefault();
            ViewBag.v2 = writerName;
            return View();
        }
        
        [AllowAnonymous]
		[HttpGet]
		public IActionResult WriterEditProfile()
		{

			var Username = User.Identity.Name;
			var UserId = c.Users.Where(x => x.UserMail == Username).Select(y => y.ID).FirstOrDefault();
			var writervalues = wm.GetById(UserId);
			return View(writervalues);
		}
        
        [HttpPost]
		[AllowAnonymous]
		public IActionResult WriterEditProfile(User p )
		{
			WriterValidator wl = new WriterValidator();
			ValidationResult results = wl.Validate(p);
			if (results.IsValid)
			{
				wm.TUpdate(p);
				return RedirectToAction("Index", "Dashboard");

			}
			else
			{
				foreach (var item in results.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

				}
				
			}
			return View();
		}
       
        [AllowAnonymous]
		[HttpGet]
		public IActionResult WriterAdd()
		{
			return View();	
			
		}

		//[AllowAnonymous]
		//[HttpPost]

		//public IActionResult WriterAdd(AddProfileImage p)
		//{
		//	Use w = new Writer();
		//	if (p.WriterImage != null)
		//	{
		//		var extension = Path.GetExtension(p.WriterImage.FileName);
		//		var newimagename = Guid.NewGuid + extension;
		//		var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newimagename);
		//		var stream = new FileStream(location, FileMode.Create);
		//		p.WriterImage.CopyTo(stream);
		//		w.WriterImage = newimagename;
		//	}



		//	w.WriterMail = p.WriterMail;
		//	w.WriterName = p.WriterName;
		//	w.WriterPassword = p.WriterPassword;
		//	w.WriterStatus = true;
		//	w.WriterAbout = p.WriterAbout;

		//	wm.TAdd(w);
		//	return RedirectToAction("Index", "Dashboard");
		//}
        public PartialViewResult WriterNavbarPartial() 
		{
            var usermail = User.Identity.Name;
            MyConnectionDbContext c = new MyConnectionDbContext();
            var writerName = c.Users.Where(x => x.UserMail == usermail).Select(y => y.UserName).FirstOrDefault();
            ViewBag.wn = writerName;
            return PartialView();
        }






    }
}
