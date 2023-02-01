namespace Companies.Core.ApplicationServices.Companies.DTOs
{
    public class AddressDTO
    {
        /// <summary>
        /// Street
        /// </summary>
        public string Street { get; set; }
        
        /// <summary>
        /// Number
        /// </summary>
        public string Number { get; set; }
        
        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }
        
        /// <summary>
        /// Address Type
        /// </summary>
        public string AddressType { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="street">Required parameter.</param>
        /// <param name="number">Required parameter.</param>
        /// <param name="city">Required parameter.</param>
        /// <param name="addressType">Required parameter.</param>
        public AddressDTO(string street, string number, string city, string addressType)
        {
            Street = street;
            Number = number;
            City = city;
            AddressType = addressType;
        }
    }
}
