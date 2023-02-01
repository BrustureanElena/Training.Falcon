using Adapters.API.Hateoas.Resources;
using System;
using System.Collections.Generic;
using Adapters.API.Validation;
using Companies.Core.ApplicationServices.Companies.Queries.ReadCompany;

namespace Companies.Adapters.API.Models
{
    /// <summary>
    /// Company Resource Model
    /// </summary>
    [ResourceValidationPrefix("Company")]
    public class CompanyResourceModel : Resource
    {
        /// <summary>
        /// Company Unique Identifier
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Company Name
        /// </summary>
        public string CompanyName { get; private set; }

        /// <summary>
        /// Bankruptcy state
        /// </summary>
        public bool IsBankrupt { get; private set; }

        /// <summary>
        /// Registration Date
        /// </summary>
        public DateTime RegistrationDate { get; private set; }

        /// <summary>
        /// Number Of Employees
        /// </summary>
        public int NumberOfEmployees { get; private set; }

        /// <summary>
        /// List of Addresses
        /// </summary>
        public IReadOnlyCollection<AddressResponse> Addresses { get; private set; }

        /// <summary>
        /// CompanyResourceModel constructor.
        /// </summary>
        public CompanyResourceModel()
        {
        }

        /// <summary>
        /// CompanyResourceModel constructor.
        /// </summary>
        /// <param name="response">Company response.</param>
        public CompanyResourceModel(CompanyResponse response)
        {
            Id = response.Id;
            CompanyName = response.CompanyName;
            IsBankrupt = response.IsBankrupt;
            RegistrationDate = response.RegistrationDate;
            NumberOfEmployees = response.NumberOfEmployees;
            Addresses = response.Addresses;
        }
    }
}