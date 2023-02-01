using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Companies.Core.ApplicationCore.Entities;
using Companies.Core.ApplicationServices.Companies.Queries;
using Companies.Core.ApplicationServices.Companies.Queries.ReadCompanies;
using Companies.Core.ApplicationServices.Companies.Queries.ReadCompany;
using Moq;
using NUnit.Framework;
using Shouldly;

namespace Companies.Core.ApplicationServices.UnitTests
{
    [TestFixture]
    public class ReadCompaniesQueryHandlerTests
    {
        [Test]
        public async Task ReadCompanies_ThreeCompaniesExist_ThreeCompaniesAreReturned()
        {
            var companiesSeedPage = GetCompanies();
            var handler = ReadCompaniesQueryHandlerFactory.Create(companiesSeedPage);
            var request = new ReadCompaniesQuery() { Pagination = new PaginationDTO() };

            PagedResult<CompanyResponse> response = await handler.Handle(request, CancellationToken.None);

            foreach (var companySeed in companiesSeedPage.Items)
            {
                response.Items.ShouldContain(x =>
                    x.Id == companySeed.Id &&
                    x.CompanyName == companySeed.CompanyName &&
                    x.IsBankrupt == companySeed.IsBankrupt &&
                    x.NumberOfEmployees == companySeed.NumberOfEmployees);
            }

            response.Items.Count.ShouldBe(companiesSeedPage.Items.Count);
            response.NextPageToken.ShouldBe(companiesSeedPage.NextPageToken);
        }

        [Test]
        public async Task ReadCompanies_FilterByNumberOfEmployees()
        {
            var companiesSeedPage = GetCompanies();
            var handlerSetup = ReadCompaniesQueryHandlerFactory.CreateWithHandlerDependencies(companiesSeedPage);
            var handler = handlerSetup.Handler;
            var request = new ReadCompaniesQuery()
            {
                Pagination = new PaginationDTO(),
                Filters = new ReadCompaniesQueryFilters() { NumberOfEmployees = 1000 }
            };

            await handler.Handle(request, CancellationToken.None);

            handlerSetup.CompaniesRepository.Verify(x => x.ReadCompanies(It.Is<ReadCompaniesQueryFilters>(f => f.NumberOfEmployees == 1000)));
        }

        [Test]
        public async Task ReadCompanies_NoCompaniesExist_EmptyListIsReturned()
        {
            var companiesSeedPage = new PagedResult<Company>(new List<Company>());
            var handler = ReadCompaniesQueryHandlerFactory.Create(companiesSeedPage);
            var request = new ReadCompaniesQuery { Pagination = new PaginationDTO() };

            PagedResult<CompanyResponse> response = await handler.Handle(request, CancellationToken.None);

            response.Items.ShouldBeEmpty();
            response.NextPageToken.ShouldBeNull();
        }

        private PagedResult<Company> GetCompanies()
        {
            var companies = new List<Company>()
            {
                new Company("Endava", new List<Address>(){new Address("Test1", "1", "Cluj-Napoca", "Commercial")}, new DateTime(2020, 01, 01), false, 1000),
                new Company("Endava", new List<Address>(){new Address("Test2", "2", "Iasi", "Correspondence")}, new DateTime(2020, 01, 01), false, 500),
                new Company("Endava", new List<Address>(){new Address("Test3", "3", "Targu Mures", "Commercial")}, new DateTime(2020, 01, 01), false, 500),
            };

            return new PagedResult<Company>(companies, nextPageToken: Guid.NewGuid().ToString());
        }
    }
}
