using BusinessLayer.Concrete;
using DataAccessLayer.EntitiyFramwork;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterMessageNotifacition :ViewComponent
    {
        MessageManager mm = new MessageManager(new EfMessageRepository());
        public IViewComponentResult Invoke()
        {
            string p;
            p = "adem@gmail.com";
            var values = mm.GetInboxListByWriter(p);
            return View(values);
        }
    }
}
