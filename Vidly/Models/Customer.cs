using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public MemberShipType MemberShipType { get; set; }
        [Required]
        [Display(Name = "MemberShip")]
        public byte MemberShipTypeID { get; set; }  // The reason is that you may need to get the membership
                                                    // with foreign_ID,
                                                    // instead of an object of the membership
        [Display(Name = "Date Of Birth")]
        public DateTime? BirthDate { get; set; }
        [Required]
        public bool IsSubscribedToNewsLetter { get; set; }
    }
}