﻿using System.ComponentModel.DataAnnotations;

namespace NorthwindAPI_LA02.Domain
{
    public class CreateCategoryRequest
    {
        [Required]
        public short CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
