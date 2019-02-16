using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.DTOs
{
    public class CustomerDto
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required !")]
        public string Name { get; set; }


        public MemberShipTypeDto MemberShipType { get; set; }

        [Required]
        public byte MemberShipTypeID { get; set; }

        //[Min18YearsForMembership]    // if not commented it will give us an exception
        public DateTime? BirthDate { get; set; }

        [Required]
        public bool IsSubscribedToNewsLetter { get; set; }
    }
}