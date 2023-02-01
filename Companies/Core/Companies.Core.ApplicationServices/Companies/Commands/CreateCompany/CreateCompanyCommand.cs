using System;
using System.Collections.Generic;
using Companies.Core.ApplicationServices.Companies.DTOs;
using Companies.Core.ApplicationServices.Companies.Queries.ReadCompany;
using EnsureThat;
using MediatR;

namespace Companies.Core.ApplicationServices.Companies.Commands.CreateCompany
{
    /// <summary>
    /// Create Company command.
    /// </summary>
    public class CreateCompanyCommand : IRequest<Guid>
    {
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

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="companyName">Required parameter.</param>
        /// <param name="registrationDate">Required parameter.</param>
        /// <param name="addresses">Required parameter.</param>
        /// <param name="isBankrupt">Required parameter.</param>
        /// <param name="numberOfEmployees">Required parameter.</param>
        /// <exception cref="ArgumentException">Throw if Company Name is null or empty.</exception>
        /// <exception cref="ArgumentException">Throw if Registration Date is default.</exception>
        /// <exception cref="ArgumentException">Throw if Addresses has no items.</exception>
        public CreateCompanyCommand(string companyName, List<AddressResponse> addresses, DateTime registrationDate, bool isBankrupt, int numberOfEmployees)
        {
            EnsureArg.IsNotNullOrEmpty(companyName);
            EnsureArg.HasItems(addresses);
            EnsureArg.IsNotDefault(registrationDate);

            CompanyName = companyName;
            Addresses = addresses;
            RegistrationDate = registrationDate;
            NumberOfEmployees = numberOfEmployees;
            IsBankrupt = isBankrupt;
        }
    }
}
