﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Webgentle.BookStore.Helpers;
using Microsoft.AspNetCore.Http;

namespace Webgentle.BookStore.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 5)]
        [Required(ErrorMessage = "Please enter the title of your book")]
        //[MyCustomValidationAttribute]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter the Author name")]
        public string Author { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public string Category { get; set; }
        [Required(ErrorMessage ="Please select any language")]
        public int LanguageId { get; set; }

        public string Language { get; set; }

        //[Required(ErrorMessage ="Please choose the languages of your book")]
        //public List<String> MultiLanguage { get; set; }

        [Required(ErrorMessage ="Please enter the total pages")]
        [Display(Name ="Total pages of book")]
        public int? TotalPages { get; set; }

        [Display(Name = "Choose the cover photo of your book")]
        [Required]
        public IFormFile CoverPhoto { get; set; }
        public string  CoverImageUrl { get; set; }

        [Display(Name = "Choose the gallery images of your book")]
        [Required]
        public IFormFileCollection GalleryFiles { get; set; }

        public List<GalleryModel> Gallery { get; set; }

    }
}
