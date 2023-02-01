using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adapters.API.Hateoas.Resources;
using Adapters.API.Validation;
using Companies.Core.ApplicationServices.Companies.Queries.ReadCompany;

namespace Companies.Adapters.API.Models
{
    /// <summary>
    /// Address Resource Model
    /// </summary>
    [ResourceValidationPrefix("Address")]
    public class AddressResourceModel : Resource
    {
        /// <summary>
        /// Address Unique Identifier
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Street name
        /// </summary>
        public string Street { get; private set; }

        /// <summary>
        /// Street number
        /// </summary>
        public string Number { get; private set; }

        /// <summary>
        /// City name
        /// </summary>
        public string City { get; private set; }

        /// <summary>
        /// Address type
        /// </summary>
        public string AddressType { get; private set; }

        /// <summary>
        /// AddressResourceModel Constructor
        /// </summary>
        /// <param name="response">Article response.</param>
        public AddressResourceModel(AddressResponse response)
        {
            Id = response.Id;
            Street = response.Street;
            Number = response.Number;
            City = response.City;
            AddressType = response.AddressType;
        }
    }
}
