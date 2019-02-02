namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MemberShipType MemberShipType { get; set; }
        public byte MemberShipTypeID { get; set; }  // The reason is that you may need to get the membership
                                                    // with foreign_ID,
                                                    // instead of an object of the membership
    }
}