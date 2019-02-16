using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime? ReleaseDate { get; set; }
        public DateTime? DateAdded { get; set; }
        [Required]
        [Range(1,20)]
        public int InStock { get; set; }
        public Genre Genre { get; set; }
        [ForeignKey("Genre")]
        [Display(Name = "Genre")]
        public int Fk_GenreId { get; set; }
    }
}