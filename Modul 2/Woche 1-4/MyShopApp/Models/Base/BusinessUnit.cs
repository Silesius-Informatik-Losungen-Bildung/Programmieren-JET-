namespace MyShopApp.Models.Base
{
    public abstract class BusinessUnit
    {
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required int PostCode { get; set; }
        public required string City { get; set; }
        public required string Street { get; set; }
    }
}
