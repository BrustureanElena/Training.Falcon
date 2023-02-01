using System;
using System.Threading.Tasks;
using Companies.Core.ApplicationCore.Entities;
using Companies.Core.ApplicationServices.Companies.Commands.CreateCompany;
using Companies.Core.ApplicationServices.Ports.Repositories;
using Moq;

namespace Companies.Core.ApplicationServices.UnitTests
{
    internal class CreateCompanyCommandHandlerFactory
    {
        internal static CreateCompanyCommandHandlerSetup CreateSetup(Guid? newCompanyId = null)
        {
            var companiesRepository = new Mock<ICompaniesRepository>();
            if (newCompanyId.HasValue)
                companiesRepository.Setup(x => x.CreateCompany(It.IsAny<Company>()))
                    .Returns(Task.FromResult(newCompanyId.Value));

            return new CreateCompanyCommandHandlerSetup
            {
                Handler = new CreateCompanyCommandHandler(companiesRepository.Object),
                CompaniesRepository = companiesRepository
            };
        }
    }

    internal class CreateCompanyCommandHandlerSetup
    {
        public CreateCompanyCommandHandler Handler { get; set; }
        public Mock<ICompaniesRepository> CompaniesRepository { get; set; }
    }
}
