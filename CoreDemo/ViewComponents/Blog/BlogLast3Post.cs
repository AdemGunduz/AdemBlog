using BusinessLayer.Concrete;
using DataAccessLayer.EntitiyFramwork;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Blog
{
	public class BlogLast3Post :ViewComponent
	{

		BlogManager bm = new BlogManager(new EfBlogRepository());
		public IViewComponentResult Invoke()
		{
			var values = bm.GetBlogListWithCategory();
			return View(values);
		}
	}
}
