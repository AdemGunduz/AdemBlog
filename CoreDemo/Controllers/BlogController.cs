using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemo.Models;
using DataAccessLayer.concrete;
using DataAccessLayer.EntitiyFramwork;
using EntityLayer.Concrate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreDemo.Controllers
{
   
   
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        MyConnectionDbContext c = new MyConnectionDbContext();
        [AllowAnonymous]
        public IActionResult Index()
        {
            var values = bm.GetBlogsWithCategoryByWriterBm();
            return View(values);
        }
        [AllowAnonymous]
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            var values = bm.GetBlogByID(id);
            return View(values);
        }
        [Authorize(Roles = "Writer")]
        public IActionResult BlogListByWriter()
        {
            var Username = User.Identity.Name;
            var UserId = c.Users.Where(x => x.UserMail == Username).Select(y => y.ID).FirstOrDefault();
            var values = bm.GetBlogListByWriter(UserId);
            return View(values);
        }
        [Authorize(Roles = "Writer")]

        [HttpGet]
        public IActionResult BlogAdd()
        {

            CategoryManager cm = new CategoryManager(new EfCategoryRepository());
            var news = new BlogVM()
            {
                Categories = cm.GetList().ToList()
            };
            return View(news);
        }
        [Authorize(Roles = "Writer")]
        [HttpPost]
        public IActionResult BlogAdd(BlogVM p)
        {
            var Username = User.Identity.Name;
            var UserId = c.Users.Where(x => x.UserMail == Username).Select(y => y.ID).FirstOrDefault();
            BlogValidator bv = new BlogValidator();
            ValidationResult results = bv.Validate(p.Blog);
            
            if (results.IsValid)
            {
                p.Blog.BlogStatus = true;
                p.Blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.Blog.UserID = UserId;
                bm.TAdd(p.Blog);
                return RedirectToAction("BlogListByWriter", "Blog");
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
        [Authorize(Roles = "Writer")]
        [HttpPost]
        public IActionResult DeleteBlog(int id)
        {
            var blogvalue = bm.TGetById(id);
            bm.TDelete(blogvalue);
            return RedirectToAction("BlogListByWriter");
        }
        [Authorize(Roles = "Writer")]
        [HttpGet]
        public IActionResult EditBlog(int id) 
        {
            var blogvalue = bm.TGetById(id);
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()

                                                   }).ToList();

            ViewBag.cv = categoryvalues;
            return View(blogvalue);
        }
        [Authorize(Roles = "Writer")]
        [HttpPost]
        
        public IActionResult EditBlog(Blog p)
        {
            p.UserID = 1;
            p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.BlogStatus = true;
            bm.TUpdate(p);
            return RedirectToAction("BlogListByWriter");

        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Delete(Blog blog, int id)
        {
            blog.BlogID = id;
            bm.TDelete(blog);
            return RedirectToAction("List", "Blog");


        }
        [Authorize(Roles = "Admin")]
        public IActionResult List(Blog blog)
        {
            var list = bm.GetList();
            return View(list);
        }


    }
}
