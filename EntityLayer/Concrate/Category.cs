using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrate
{
    public class Category
    {
        // property tanımlamak için erişim belirteci-değişken türü-isim-get,set

        [Key]
        public  int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }

        public bool CategoryStatus { get; set; }

        public virtual List<Blog> Blogs { get; set; }

    }
}
