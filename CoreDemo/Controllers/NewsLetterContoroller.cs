using BusinessLayer.Concrete;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.EntitiyFramwork;

namespace CoreDemo.Controllers
{
	public class NewsLetterContoroller : Controller
	{
		NewsLetterManager nm = new NewsLetterManager(new EfNewsLetterRepository());
		

		[HttpGet]
		public PartialViewResult SubscribeMail()
		{
			return PartialView();
		}
		[HttpPost]
		public PartialViewResult SubscribeMail(NewsLetter p)
		{
			p.MailStatus = true;
			nm.NewsLetterAdd(p);
			return PartialView();
		}
	}
}
