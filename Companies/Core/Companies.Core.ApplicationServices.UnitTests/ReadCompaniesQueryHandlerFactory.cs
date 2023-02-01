using Companies.Core.ApplicationCore.Entities;
using Companies.Core.ApplicationServices.Companies.Queries.ReadCompanies;
using Companies.Core.ApplicationServices.Ports.Repositories;
using Moq;
using System.Threading.Tasks;

namespace Companies.Core.ApplicationServices.UnitTests
{
    public class ReadCompaniesQueryHandlerFactory
    {
        public static ReadCompaniesQueryHandler Create(ICompaniesRepository repository)
        {
            return new ReadCompaniesQueryHandler(repository);
        }

        public static ReadCompaniesQueryHandler Create(PagedResult<Company> companies)
        {
            var repository = new Mock<ICompaniesRepository>();
            repository.Setup(r => r.ReadCompanies(It.IsAny<ReadCompaniesQueryFilters>()))
                .Returns(Task.FromResult(companies));

            return new ReadCompaniesQueryHandler(repository.Object);
        }

        public static ReadCompaniesQueryHandlerSetup CreateWithHandlerDependencies(PagedResult<Company> companies)
        {
            var repository = new Mock<ICompaniesRepository>();
            repository.Setup(r => r.ReadCompanies(It.IsAny<ReadCompaniesQueryFilters>()))
                .Returns(Task.FromResult(companies));

            var handler = new ReadCompaniesQueryHandler(repository.Object);
            return new ReadCompaniesQueryHandlerSetup
            {
                Handler = handler,
                CompaniesRepository = repository
            };
        }
    }

    public class ReadCompaniesQueryHandlerSetup
    {
        public ReadCompaniesQueryHandler Handler { get; set; }
        public Mock<ICompaniesRepository> CompaniesRepository { get; set; }
    }
}