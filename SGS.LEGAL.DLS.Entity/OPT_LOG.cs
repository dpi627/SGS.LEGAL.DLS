using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGS.LEGAL.DLS.Entity
{
    public record OPT_LOG : BaseModel
    {
        [Key]
        [Required]
        public long LOG_ID { get; set; }
        [Required]
        public int ACT_ID { get; set; }
        public string? MSG { get; set; }
        public string? MEMO { get; set; }
    }
}
