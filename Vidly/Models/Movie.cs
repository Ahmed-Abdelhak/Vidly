using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        public int InStock { get; set; }
        public Genre Genre { get; set; }
        [ForeignKey("Genre")]
        public int Fk_GenreId { get; set; }
    }
}