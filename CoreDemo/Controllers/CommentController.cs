using BusinessLayer.Concrete;
using DataAccessLayer.EntitiyFramwork;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CoreDemo.Controllers
{
	public class CommentController : Controller
	{
		CommentManager cm = new CommentManager(new EfCommentRepository());
		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public PartialViewResult PartialAddComment()
		{
			return PartialView();
		}
		[HttpPost]
		public PartialViewResult PartialAddComment(Comment p)
		{
			p.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			p.CommentStatus = true;
			p.BlogID = 2;
			cm.CommentAdd(p);

			return PartialView();
		}
		public PartialViewResult CommenListByBlog(int id)
		{
			var values = cm.GetList(id);
			return PartialView(values);
		}

        [Authorize(Roles = "Admin")]
        [HttpPost]
		public IActionResult Delete(Comment comment , int id)
		{
			comment.CommentID= id;	
			cm.Delete(comment);
            return RedirectToAction("List", "Comment");


        }
        [Authorize(Roles = "Admin")]
        public IActionResult List(Comment comment)
		{
            var list = cm.GetList();
            return View(list);
        }

    }
}
