using Companies.Core.ApplicationCore.Entities;
using Companies.Core.ApplicationServices.Companies.Queries.ReadCompanies;
using System;
using System.Threading.Tasks;
using Companies.Core.ApplicationServices.Ports.Exceptions;

namespace Companies.Core.ApplicationServices.Ports.Repositories
{
    public interface ICompaniesRepository
    {
        /// <summary>
        /// Creates a new company.
        /// </summary>
        /// <param name="company">Company object. Required parameter.</param>
        /// <returns>Unique identifier of newly created company.</returns>
        Task<Guid> CreateCompany(Company company);

        /// <summary>
        /// Reads an existing company.
        /// </summary>
        /// <param name="id">Unique identifier of retrievable company.</param>
        /// <returns>Company object.</returns>
        /// <exception cref="NotFoundException">Throw if querying for an invalid unique identifier.</exception>
        Task<Company> ReadCompany(Guid id);

        /// <summary>
        /// Reads multiple companies based on filters.
        /// </summary>
        /// <param name="companiesFilter">A filter that can have multiple values based on configuration.</param>
        /// <returns>PagedResult of companies.</returns>
        Task<PagedResult<Company>> ReadCompanies(ReadCompaniesQueryFilters companiesFilter);
    }
}
