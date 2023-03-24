using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntitiyFramwork;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CoreDemo.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index()
        {
            var values = cm.GetList();
            return View(values);
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            cm.TAdd(category);
            return RedirectToAction("List", "Category");
        }
        public IActionResult Create( )
        {
            return View();

        }
        public IActionResult List(Category category)
        {
            var list = cm.GetList();
            return View(list);


        }
        public IActionResult Edit(int id)
        {
            var row = cm.TGetById(id);
            return View(row);


        }
        [HttpPost]
        public IActionResult Edit(Category category, int id)
        {
            category.CategoryID = id;
            category.CategoryStatus = true;
            cm.TUpdate(category);
            return RedirectToAction("List", "Category");


        }
        [HttpPost]
        public IActionResult Delete(Category category , int id)
        {
           category.CategoryID = id;  
           cm.TDelete(category);
            return RedirectToAction("List","Category");  
        }
    }
}
