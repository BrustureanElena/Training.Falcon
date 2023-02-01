using Companies.Core.ApplicationCore.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Companies.Core.ApplicationServices.Ports.Exceptions;
using Companies.Core.ApplicationServices.Ports.Repositories;

namespace Companies.Core.ApplicationServices.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, Guid>
    {
        private readonly ICompaniesRepository _companiesRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="companiesRepository">Required parameter.</param>
        public CreateCompanyCommandHandler(ICompaniesRepository companiesRepository)
        {
            _companiesRepository = companiesRepository;
        }

        /// <summary>
        /// Creates a new Company.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Returns the Id of the newly created company.</returns>
        public Task<Guid> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                List<Address> addresses = new List<Address>();
                foreach (var requestAddress in request.Addresses)
                {
                    addresses.Add(new Address(
                        requestAddress.Street,
                        requestAddress.Number,
                        requestAddress.City,
                        requestAddress.AddressType));
                }

                var company = new Company(request.CompanyName, addresses, request.RegistrationDate, request.IsBankrupt,
                    request.NumberOfEmployees);

                return _companiesRepository.CreateCompany(company);
            }
            catch (ArgumentException a)
            {
                throw new ArgumentException(a.Message);
            }
            catch (NotEnoughSpaceException nes)
            {
                // TODO: Throw genereic ServerException happened.
                // TODO: LOG the reason so we can come back to it later.

                throw new NotEnoughSpaceException(nes.Message);
            }
        }
    }
}
