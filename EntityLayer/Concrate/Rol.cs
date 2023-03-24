using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrate;

    public class Rol
    {
        [Key]
        public int RolID { get; set; }
        public string RolName { get; set; }
    }

