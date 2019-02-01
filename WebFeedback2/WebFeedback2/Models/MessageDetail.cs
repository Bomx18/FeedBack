using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebFeedback2.Models
{
    public class MessageDetail
    {

        [Key]
        public int MessageID { get; set; }
        [Required]
        [Column(TypeName = "varchar(150)")]
        public string TextMessage { get; set; }

        //public ICollection<UserDetail> UserDetail { get; set; }

    }
}
