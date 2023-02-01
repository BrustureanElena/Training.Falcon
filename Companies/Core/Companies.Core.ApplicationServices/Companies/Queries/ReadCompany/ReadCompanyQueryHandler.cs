using System.Threading.Tasks;
using Companies.Core.ApplicationServices.Companies.Exceptions;
using Companies.Core.ApplicationServices.Ports.Exceptions;
using Companies.Core.ApplicationServices.Ports.Repositories;

namespace Companies.Core.ApplicationServices.Companies.Queries.ReadCompany
{
    public class ReadCompanyQueryHandler : BaseRequestHandler<ReadCompanyQuery, CompanyResponse>
    {
        /// <summary>
        /// Company repository
        /// </summary>
        private readonly ICompaniesRepository _companiesRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="companiesRepository">Required parameter.</param>
        public ReadCompanyQueryHandler(ICompaniesRepository companiesRepository)
        {
            _companiesRepository = companiesRepository;
        }

        ///// <summary>
        ///// Reads an existing company.
        ///// </summary>
        ///// <param name="request">Required parameter.</param>
        ///// <returns>CompanyResponse object.</returns>
        ///// <exception cref="NotFoundRequestException">Throw if querying for an invalid unique identifier.</exception>
        public override async Task<CompanyResponse> InnerHandle(ReadCompanyQuery request)
        {
            try
            {
                var company = await _companiesRepository.ReadCompany(request.Id);
                return new CompanyResponse(company);
            }
            catch (NotFoundException)
            {
                throw new NotFoundRequestException();
            }
        }
    }
}
