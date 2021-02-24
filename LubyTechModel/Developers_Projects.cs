using System.ComponentModel.DataAnnotations;

namespace LubyTechModel.Models
{
    public class Developers_Projects
    {
        [Key]
        public int Id { get; set; }
        public int DeveloperId { get; set; }
        public int ProjectId { get; set; }
        //public virtual Project Project { get; set; }
        //public virtual Developer Developer { get; set; }
    }
}
