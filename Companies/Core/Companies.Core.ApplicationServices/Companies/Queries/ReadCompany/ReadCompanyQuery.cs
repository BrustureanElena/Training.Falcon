using EnsureThat;
using System;
using MediatR;

namespace Companies.Core.ApplicationServices.Companies.Queries.ReadCompany
{
    /// <summary>
    /// Retrieve one Company.
    /// </summary>
    /// <returns>Company</returns>
    public class ReadCompanyQuery : IRequest<CompanyResponse>
    {
        /// <summary>
        /// Company Identifier
        /// </summary>
        public Guid Id { get; }
        
        /// <summary>
        /// Retrieves a Company
        /// </summary>
        /// <param name="id">Company Identifier</param>
        public ReadCompanyQuery(Guid id)
        {
            Ensure.Guid.IsNotEmpty(id, nameof(id));
            Id = id;
        }
    }
}
