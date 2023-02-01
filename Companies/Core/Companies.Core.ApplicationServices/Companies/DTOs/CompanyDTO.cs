using System;
using System.Collections.Generic;

namespace Companies.Core.ApplicationServices.Companies.DTOs
{
    public class CompanyDTO
    {
        /// <summary>
        /// Company Name
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Bankruptcy state
        /// </summary>
        public bool IsBankrupt { get; set; }

        /// <summary>
        /// Registration Date
        /// </summary>
        public DateTime RegistrationDate { get; set; }

        /// <summary>
        /// Number Of Employees
        /// </summary>
        public int NumberOfEmployees { get; set; }

        /// <summary>
        /// Addresses
        /// </summary>
        public List<AddressDTO> Addresses { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="companyName">Required parameter.</param>
        /// <param name="registrationDate">Required parameter.</param>
        /// <param name="addresses">Required parameter.</param>
        /// <param name="isBankrupt">Required parameter.</param>
        /// <param name="numberOfEmployees">Required parameter.</param>
        public CompanyDTO(string companyName, List<AddressDTO> addresses, DateTime registrationDate, bool isBankrupt, int numberOfEmployees)
        {
            CompanyName = companyName;
            Addresses = addresses;
            RegistrationDate = registrationDate;
            IsBankrupt = isBankrupt;
            NumberOfEmployees = numberOfEmployees;
        }
    }
}
