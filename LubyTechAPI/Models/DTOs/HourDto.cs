using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LubyTechAPI.Models.DTOs
{
    public class HourDto
    {
        public DateTime dateBegin { get; set; }
        public DateTime dateEnd { get; set; }        
        public int DeveloperId { get; set; }
        public int ProjectId { get; set; }
        public DateTime created { get; set; }
    }
}
