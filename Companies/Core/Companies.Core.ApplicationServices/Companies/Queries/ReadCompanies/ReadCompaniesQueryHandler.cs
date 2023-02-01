using Companies.Core.ApplicationCore.Entities;
using Companies.Core.ApplicationServices.Ports.Repositories;
using MediatR;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Companies.Core.ApplicationServices.Companies.Queries.ReadCompany;

namespace Companies.Core.ApplicationServices.Companies.Queries.ReadCompanies
{
    public class ReadCompaniesQueryHandler : IRequestHandler<ReadCompaniesQuery, PagedResult<CompanyResponse>>
    {
        /// <summary>
        /// Company repository
        /// </summary>
        private readonly ICompaniesRepository _companiesRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="companiesRepository">Required parameter.</param>
        public ReadCompaniesQueryHandler(ICompaniesRepository companiesRepository)
        {
            _companiesRepository = companiesRepository;
        }

        /// <summary>
        /// Reads multiple companies based on filters
        /// </summary>
        /// <param name="request">Required parameter.</param>
        /// <param name="cancellationToken">Required parameter.</param>
        /// <returns>PagedResult of companies</returns>
        public async Task<PagedResult<CompanyResponse>> Handle(ReadCompaniesQuery request, CancellationToken cancellationToken)
        {
            var companiesFilters = new ReadCompaniesQueryFilters
            {
                NumberOfEmployees = request.Filters?.NumberOfEmployees,
            };

            var pagedCompanies = await _companiesRepository.ReadCompanies(companiesFilters);
            return Map(pagedCompanies);
        }

        private PagedResult<CompanyResponse> Map(PagedResult<Company> pagedCompanies)
        {
            var companyResponses = pagedCompanies.Items.Select(c => new CompanyResponse(c)).ToList();
            return new PagedResult<CompanyResponse>(companyResponses, pagedCompanies.NextPageToken);
        }
    }
}
