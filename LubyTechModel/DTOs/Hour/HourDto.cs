using System;

namespace LubyTechModel.Models.DTOs
{
    public class HourDto
    {
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }        
        public int DeveloperId { get; set; }
        public int ProjectId { get; set; }
        public DateTime Created { get; set; }
    }
}
