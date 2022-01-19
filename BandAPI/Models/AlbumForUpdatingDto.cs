using BandAPI.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BandAPI.Models
{
    /*[TitleAndDescription(ErrorMessage = "Title Must Be Different From Description")]
    public class AlbumForUpdatingDto
    {
        [Required(ErrorMessage = "Title needs to be filled in")]
        [MaxLength(200, ErrorMessage = "Title needs to be up to 200 characters")]
        public String Title { get; set; }

        [Required]
        [MaxLength(400, ErrorMessage = "Description needs to be up to 200 characters")]
        public String Description { get; set; }
    }
    */
    public class AlbumForUpdatingDto : AlbumManipulationDto
    {
        [Required(ErrorMessage = "You need to fill description")]
        public override string Description { get => base.Description; set => base.Description = value; }
    }
}
