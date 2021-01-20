using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LubyTechAPI.Models
{
    public class Hour
    {
        [Key]
        public int Id { get; set; }

        public DateTime dateBegin { get;set; }
        public DateTime dateEnd { get;set; }        
        public double Time { get;set; }        

        [Required]
        public int DeveloperId { get; set; }

        [ForeignKey("DeveloperId")]
        public virtual Developer Developer { get; set; }
        
        [Required]
        public int ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }

        public DateTime created { get; set; }
    }
}
