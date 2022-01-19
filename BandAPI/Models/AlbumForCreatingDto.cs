using BandAPI.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BandAPI.Models
{
    /*
    [TitleAndDescription(ErrorMessage="Title Must Be Different From Description")]
    public class AlbumForCreatingDto // : IValidatableObject
    {
        [Required(ErrorMessage = "Title needs to be filled in")]
        [MaxLength(200, ErrorMessage = "Title needs to be up to 200 characters")]
        public String Title { get; set; }

        [MaxLength(400, ErrorMessage = "Description needs to be up to 200 characters")]
        public String Description { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(Title == Description)
            {
                yield return new ValidationResult("The title and description need to be different", new[] {"AlbumForCreatingDto"});
            }
        }
        //public Guid BandId { get; set; }
    }
    */
    [TitleAndDescription(ErrorMessage = "Title Must Be Different From Description")]
    public class AlbumForCreatingDto : AlbumManipulationDto
    {

    }
}
