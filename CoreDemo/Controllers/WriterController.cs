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
		WriterManager wm = new WriterManager(new EfWriterRepository());
		[Authorize]
		public IActionResult Index()
		{
			var usermail = User.Identity.Name;
			ViewBag.v = usermail;
			MyConnectionDbContext c = new MyConnectionDbContext();
			var writerName = c.Writers.Where(x=>x.WriterMail==usermail).Select(y=>y.WriterName).FirstOrDefault(); 
			ViewBag.v2=writerName;
			return View();
		}
		[Authorize]
		public IActionResult WriterProfile()
		{
			return View();
		}
        [Authorize]

        public IActionResult WriterMail()

		{
			return View();
		}
        [Authorize]
        public IActionResult Test()
		{
            var usermail = User.Identity.Name;
            ViewBag.v = usermail;
            MyConnectionDbContext c = new MyConnectionDbContext();
            var writerName = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.v2 = writerName;
            return View();
        }
        [Authorize]
        [AllowAnonymous]
		[HttpGet]
		public IActionResult WriterEditProfile()
		{
            
			
            var writervalues = wm.TGetById(1);
			return View(writervalues);
		}
        [Authorize]
        [HttpPost]
		[AllowAnonymous]
		public IActionResult WriterEditProfile(Writer p )
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
        [Authorize]
        [AllowAnonymous]
		[HttpGet]
		public IActionResult WriterAdd()
		{
			return View();	
			
		}
        [Authorize]
        [AllowAnonymous]
        [HttpPost]

        public IActionResult WriterAdd(AddProfileImage p)
		{
			Writer w = new Writer();
			if (p.WriterImage != null)
			{
				var extension = Path.GetExtension(p.WriterImage.FileName);
				var newimagename = Guid.NewGuid + extension;
				var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newimagename);
				var stream  = new FileStream(location,FileMode.Create);	
				p.WriterImage.CopyTo(stream);
				w.WriterImage = newimagename;
            }



			w.WriterMail = p.WriterMail;
			w.WriterName= p.WriterName;
			w.WriterPassword= p.WriterPassword;
			w.WriterStatus = true;
			w.WriterAbout = p.WriterAbout;

			wm.TAdd(w);
			return RedirectToAction("Index", "Dashboard");
		}
        [Authorize]
        public PartialViewResult WriterNavbarPartial() 
		{
            var usermail = User.Identity.Name;
            MyConnectionDbContext c = new MyConnectionDbContext();
            var writerName = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.wn = writerName;
            return PartialView();
        }






    }
}
