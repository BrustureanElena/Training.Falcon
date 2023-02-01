using MediatR;
using Companies.Core.ApplicationServices.Companies.Queries.ReadCompany;

namespace Companies.Core.ApplicationServices.Companies.Queries.ReadCompanies
{
    public class ReadCompaniesQuery : IRequest<PagedResult<CompanyResponse>>
    {
        /// <summary>
        /// Pagination information such as limit and next page token.
        /// </summary>
        public PaginationDTO Pagination { get; set; }

        /// <summary>
        /// Filtering information such as NumberOfEmployees field.
        /// </summary>
        public ReadCompaniesQueryFilters Filters { get; set; }
    }    
}
