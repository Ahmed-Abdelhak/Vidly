using System.Collections.Generic;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class AddMoviewViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Genre> Genre { get; set; }
    }
}