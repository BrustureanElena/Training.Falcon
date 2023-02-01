using EnsureThat;
using System;
using System.Collections.Generic;

namespace Companies.Core.ApplicationCore.Entities
{
    public class Company
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
        public List<Address> Addresses { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="companyName">Required parameter.</param>
        /// <param name="addresses">Required parameter.</param>
        /// <param name="registrationDate">Required parameter.</param>
        /// <param name="isBankrupt">Required parameter.</param>
        /// <param name="numberOfEmployees">Required parameter.</param>
        public Company(string companyName, List<Address> addresses, DateTime registrationDate, bool isBankrupt, int numberOfEmployees)
        {
            Id = Guid.NewGuid();
            SetCompanyName(companyName);
            SetRegistrationDate(registrationDate);
            SetAddresses(addresses);
            SetBankrupt(isBankrupt);
            SetNumberOfEmployees(numberOfEmployees);
        }

        /// <summary>
        /// Registration Date Setter
        /// </summary>
        /// <param name="registrationDate">Required parameter.</param>
        /// <exception cref="ArgumentException">Throw if Registration Date is default.</exception>
        /// <exception cref="ArgumentException">Throw if Registration Date is greater than now.</exception>
        public void SetRegistrationDate(DateTime registrationDate)
        {
            EnsureArg.IsNotDefault(registrationDate);
            if(registrationDate > DateTime.Now)
            {
                throw new ArgumentException("Registration date can't be in the future.");
            }

            RegistrationDate = registrationDate;
        }

        /// <summary>
        /// Company Name Setter
        /// </summary>
        /// <param name="companyName">Required parameter.</param>
        /// <exception cref="ArgumentException">Throw if Company Name is null or empty.</exception>
        public void SetCompanyName(string companyName)
        {
            EnsureArg.IsNotNullOrEmpty(companyName);
            CompanyName = companyName;
        }

        /// <summary>
        /// Number Of Employees Setter
        /// </summary>
        /// <param name="numberOfEmployees">Required parameter.</param>
        /// <exception cref="ArgumentException">Throw if Number Of Employees is lower than 0.</exception>
        public void SetNumberOfEmployees(int numberOfEmployees)
        {
            if(numberOfEmployees < 0)
            {
                throw new ArgumentException("Number of employees can't be lower than 0.");
            }

            NumberOfEmployees = numberOfEmployees;
        }

        /// <summary>
        /// Bankruptcy state setter.
        /// </summary>
        /// <param name="isBankrupt">Required parameter.</param>
        public void SetBankrupt(bool isBankrupt)
        {
            IsBankrupt = isBankrupt;
        }

        /// <summary>
        /// Addresses setter.
        /// </summary>
        /// <param name="addresses">Required parameter.</param>
        /// <exception cref="ArgumentException">Throw if address does not have any items.</exception>
        public void SetAddresses(List<Address> addresses)
        {
            EnsureArg.HasItems(addresses);
            Addresses = addresses;
        }
    }
}
