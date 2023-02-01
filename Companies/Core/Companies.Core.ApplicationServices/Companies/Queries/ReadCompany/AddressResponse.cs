using System;
using Companies.Core.ApplicationCore.Entities;

namespace Companies.Core.ApplicationServices.Companies.Queries.ReadCompany
{
    public class AddressResponse
    {
        /// <summary>
        /// Address Identifier
        /// </summary>
        public Guid Id { get; set; }
        
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
        /// <param name="address">Address parameter.</param>
        public AddressResponse(Address address)
        {
            Id = address.Id;
            Street = address.Street;
            Number = address.Number;
            City = address.City;
            AddressType = AddressType;
        }
    }
}
