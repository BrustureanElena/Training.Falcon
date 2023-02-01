using Companies.Core.ApplicationCore.Entities;
using Companies.Core.ApplicationServices.Companies.Queries.ReadCompany;
using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Companies.Core.ApplicationServices.Ports.Exceptions;

namespace Companies.Core.ApplicationServices.UnitTests
{
    [TestFixture]
    class ReadCompanyQueryHandlerTests
    {
        [Test]
        public async Task ReadCompany_ValidData_ReturnsSuccessAsync()
        {
            // Arrange
            var addresses = new List<Address>();
            var address = new Address("Test", "1", "Cluj", "Commercial");
            addresses.Add(address);
            var companySeed = new Company("Endava", addresses, DateTime.Now, false, 8000);

            var handler = ReadCompanyQueryHandlerFactory.Create(companySeed);
            var request = new ReadCompanyQuery(companySeed.Id);

            // Act
            var response = await handler.Handle(request, CancellationToken.None);

            // Assert
            response.ShouldSatisfyAllConditions(
                () => response.Id.ShouldBe(companySeed.Id),
                () => response.CompanyName.ShouldBe(companySeed.CompanyName),
                () => response.IsBankrupt.ShouldBe(companySeed.IsBankrupt),
                () => response.Addresses.First().City.ShouldBe(address.City),
                () => response.NumberOfEmployees.ShouldBe(companySeed.NumberOfEmployees),
                () => response.RegistrationDate.ShouldBe(companySeed.RegistrationDate)
            );
        }

        [Test]
        public async Task ReadCompany_CompanyDoesNotExist_ThrowsArgumentException()
        {
            var handler = ReadCompanyQueryHandlerFactory.Create<NotFoundException>();
            var request = new ReadCompanyQuery(Guid.Parse("a642f89a-1228-4ce5-a06b-b9878a96cd07"));

            try
            {
                await handler.Handle(request, CancellationToken.None);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                ex.ShouldBeOfType<NotFoundException>();
            }
        }
    }
}
