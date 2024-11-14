using System.ComponentModel.DataAnnotations;

namespace NorthwindAPI_LA02.Domain
{
    public class UpdateCategoryRequest
    {
        [Required]
        public string CategoryName { get; set; }

        public string Description { get; set; }
    }
}
