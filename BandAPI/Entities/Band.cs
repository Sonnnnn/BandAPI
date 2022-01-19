using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BandAPI.Entities
{
    public class Band
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public String Name { get; set; }

        public DateTime Founded { get; set; }

        [Required]
        [MaxLength(50)]
        public String MainGenre { get; set; }
        public ICollection<Album> albums { get; set; } = new List<Album>();

    }
}
