using BusinessLayer.Concrete;
using DataAccessLayer.EntitiyFramwork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CoreDemo.ViewComponents.Category
{
	public class CategoryList:ViewComponent
	{
		CategoryManager cm = new CategoryManager(new EfCategoryRepository());

		public IViewComponentResult Invoke()
		{
			var values = cm.GetList();
			return View(values);
		}
	}
}
