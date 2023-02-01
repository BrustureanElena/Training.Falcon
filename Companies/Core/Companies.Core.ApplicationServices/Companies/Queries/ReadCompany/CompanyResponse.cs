using Companies.Core.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Companies.Core.ApplicationServices.Companies.Queries.ReadCompany
{
    public class CompanyResponse
    {
        /// <summary>
        /// Company Unique Identifier
        /// </summary>
        public Guid Id { get; }
        
        /// <summary>
        /// Company Name
        /// </summary>
        public string CompanyName { get; }

        /// <summary>
        /// Bankruptcy state
        /// </summary>
        public bool IsBankrupt { get; }

        /// <summary>
        /// Registration Date
        /// </summary>
        public DateTime RegistrationDate { get; }

        /// <summary>
        /// Number Of Employees
        /// </summary>
        public int NumberOfEmployees { get; }

        /// <summary>
        /// Addresses
        /// </summary>
        public IReadOnlyCollection<AddressResponse> Addresses { get; }

        internal CompanyResponse(Company company)
        {
            Id = company.Id;
            CompanyName = company.CompanyName;
            RegistrationDate = company.RegistrationDate;
            IsBankrupt = company.IsBankrupt;
            NumberOfEmployees = company.NumberOfEmployees;
            Addresses = company.Addresses.Select(a => new AddressResponse(a)).ToList();
        }
    }
}
