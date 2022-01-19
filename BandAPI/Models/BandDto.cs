using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandAPI.Models
{
    public class BandDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FoundedYearAgo { get; set; }
        public string MainGenre { get; set; }
      
    }
}
