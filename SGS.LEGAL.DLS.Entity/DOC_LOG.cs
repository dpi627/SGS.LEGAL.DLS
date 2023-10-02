using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGS.LEGAL.DLS.Entity
{
    public record DOC_LOG : BaseModel
    {
        [Key]
        [Required]
        public string? DOC_ID { get; set; }
        public long BD_ID_1ST { get; set; }
        [Required]
        public string FIL_TYP { get; set; }
        [Required]
        public string LET_TYP { get; set; }
        public string? BAK_PATH { get; set; }
    }
}
