using System;
using System.Threading.Tasks;
using Companies.Core.ApplicationCore.Entities;
using Companies.Core.ApplicationServices.Companies.Queries.ReadCompany;
using Companies.Core.ApplicationServices.Ports.Repositories;
using Moq;

namespace Companies.Core.ApplicationServices.UnitTests
{
    public class ReadCompanyQueryHandlerFactory
    {
        public static ReadCompanyQueryHandler Create(Company company)
        {
            var repository = new Mock<ICompaniesRepository>();
            repository.Setup(r => r.ReadCompany(company.Id)).Returns(Task.FromResult(company));

            return new ReadCompanyQueryHandler(repository.Object);
        }

        public static ReadCompanyQueryHandler Create<TException>() where TException : Exception, new()
        {
            var repository = new Mock<ICompaniesRepository>();
            repository.Setup(r => r.ReadCompany(It.IsAny<Guid>())).Throws<TException>();

            return new ReadCompanyQueryHandler(repository.Object);
        }
    }
}
