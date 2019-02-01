using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebFeedback2.Models
{
    public class ThemeDetail
    {
        [Key]
        public int ThemeID { get; set; }
        [Required]
        [Column(TypeName = "varchar(150)")]
        public string TextTheme { get; set; }
    }
}
