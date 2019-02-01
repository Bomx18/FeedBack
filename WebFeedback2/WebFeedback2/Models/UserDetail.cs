using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebFeedback2.Models
{
    

    public class UserDetail 
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(16)")]
        public string UserName { get; set; }
        [Required]
        [Column(TypeName = "varchar(254)")]
        public string UserEmail { get; set; }
        [Required]
        [Column(TypeName = "varchar(10)")]
        public string UserNumPhone { get; set; }
        [Required]
        [Column(TypeName = "int")]

       // [ForeignKey("Message")]
        public int IDMessage { get; set; }
        //public  MessageDetail MessageDetail { get; set; }
        [Required]
        //[Column(TypeName = "int")]
        public int IDTheme { get; set; }

    }
    


}