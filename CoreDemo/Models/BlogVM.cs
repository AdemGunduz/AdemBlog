using EntityLayer.Concrate;

namespace CoreDemo.Models
{
    public class BlogVM
    {
        public virtual Blog Blog { get; set; }
        public virtual List<Category> Categories { get; set; }
       

    }
}
