
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrate;

public class User
{
    [Key]
    public int ID { get; set; }
    public int RoleId { get; set; }
    public string UserName { get; set; }
    public string UserMail { get; set; }
    public string UserPassword { get; set; }
    public bool UserStatus { get; set; }
   
}

