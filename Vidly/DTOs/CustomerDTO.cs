using System;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.DTOs
{
    public class CustomerDto
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required !")]
        public string Name { get; set; }

        [Required]
        public byte MemberShipTypeID { get; set; }

        [Min18YearsForMembership]
        public DateTime? BirthDate { get; set; }

        [Required]
        public bool IsSubscribedToNewsLetter { get; set; }
    }
}