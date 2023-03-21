using BusinessLayer.Concrete;
using DataAccessLayer.EntitiyFramwork;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class NotificationController1 : Controller
    {
        NotificationManager nm = new NotificationManager(new EfNotificationRepository());
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllNotification()
        {
            var values = nm.GetList();
            return View(values);    
        }
    }
}
