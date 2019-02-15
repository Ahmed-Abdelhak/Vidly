namespace Vidly.Models
{
    public class MemberShipType
    {

        public byte Id { get; set; }           // not many, so byte is enough
        public byte DurationInMonths { get; set; }    // from 1 to 12
        public float DiscountRate { get; set; }    // from 1% to 100%
        public float SignUpFee { get; set; }
        public string Name { get; set; }

        public static readonly byte Free = 1;
    }
}