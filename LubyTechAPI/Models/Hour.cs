using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LubyTechAPI.Models
{
    public class Hour
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "You must to select when the Data Begin.")]
        public DateTime DateBegin { get;set; }
        [Required(ErrorMessage = "You must to select when the Data End.")]
        public DateTime DateEnd { get;set; }        
        public double Time { get;set; }

        [Required(ErrorMessage = "You must to select a Developer.")]
        public int DeveloperId { get; set; }

        [ForeignKey("DeveloperId")]
        public virtual Developer Developer { get; set; }

        [Required(ErrorMessage = "You must to select a Project.")]
        public int ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }

        public DateTime Created { get; set; }
    }
}
