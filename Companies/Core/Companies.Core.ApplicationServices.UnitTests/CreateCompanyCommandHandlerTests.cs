using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Companies.Core.ApplicationCore.Entities;
using Companies.Core.ApplicationServices.Companies.Commands.CreateCompany;
using Companies.Core.ApplicationServices.Companies.DTOs;
using Companies.Core.ApplicationServices.Companies.Queries.ReadCompany;
using Moq;
using NUnit.Framework;
using Shouldly;

namespace Companies.Core.ApplicationServices.UnitTests
{
    [TestFixture]
    public class CreateCompanyCommandHandlerTests
    {
        [Test]
        public async Task HandleRequest_Success()
        {
            var id = Guid.NewGuid();
            var command = new CreateCompanyCommand("Endava",
                new List<AddressResponse>() {new AddressResponse(new Address("Test", "10", "Cluj-Napoca", "Commercial"))}, DateTime.Now, false,
                8000);
            var commandHandlerSetup = CreateCompanyCommandHandlerFactory.CreateSetup(id);
            var commandHandler = commandHandlerSetup.Handler;

            var companyId = await commandHandler.Handle(command, CancellationToken.None);

            companyId.ShouldBe(id);

            commandHandlerSetup.CompaniesRepository.Verify(
                x => x.CreateCompany(It.Is<Company>
                (company => company.CompanyName == command.CompanyName &&
                            company.IsBankrupt == command.IsBankrupt &&
                            company.NumberOfEmployees == command.NumberOfEmployees &&
                            company.RegistrationDate == command.RegistrationDate
                )));
        }

        //    [Test]
        //    public void CreateCompany_ValidData_ReturnsExistingCompany()
        //    {
        //        // Arrange
        //        List<AddressDTO> addresses = new List<AddressDTO>();
        //        AddressDTO clujAddress = new AddressDTO("Strada Alexandru Vaida Voevod", "51", "Cluj-Napoca", "Commercial");
        //        addresses.Add(clujAddress);
        //        CancellationToken cancellationToken;

        //        // Act
        //        CreateCompanyCommand request = new CreateCompanyCommand("Endava", addresses, DateTime.Now, false, 8000);
        //        CreateCompanyCommandHandler requestHandler = new CreateCompanyCommandHandler(companiesMockRepository.Object);
        //        var response = requestHandler.Handle(request, cancellationToken);

        //        // Assert
        //        response.ShouldBeOfType<Task<Guid>>();
        //    }

        //    [Test]
        //    public void CreateCompany_EmptyCompanyName_ThrowsArgumentException()
        //    {
        //        // Arrange
        //        List<AddressDTO> addresses = new List<AddressDTO>();
        //        AddressDTO clujAddress = new AddressDTO("Strada Alexandru Vaida Voevod", "51", "Cluj-Napoca", "Commercial");
        //        addresses.Add(clujAddress);

        //        // Act
        //        ActualValueDelegate<CreateCompanyCommand> createCompanyCommandDelegate = () => new CreateCompanyCommand("", addresses, DateTime.Now, false, 8000);

        //        // Assert
        //        Assert.That(createCompanyCommandDelegate, Throws.TypeOf<ArgumentException>());
        //    }

        //    [Test]
        //    public void CreateCompany_DefaultRegistrationDate_ThrowsArgumentException()
        //    {
        //        // Arrange
        //        List<AddressDTO> addresses = new List<AddressDTO>();
        //        AddressDTO clujAddress = new AddressDTO("Strada Alexandru Vaida Voevod", "51", "Cluj-Napoca", "Commercial");
        //        addresses.Add(clujAddress);

        //        // Act
        //        ActualValueDelegate<CreateCompanyCommand> createCompanyCommandDelegate = () => new CreateCompanyCommand("Endava", addresses, default, false, 8000);

        //        // Assert
        //        Assert.That(createCompanyCommandDelegate, Throws.TypeOf<ArgumentException>());
        //    }

        //    [Test]
        //    public void CreateCompany_ZeroItemsInAddresses_ThrowsArgumentException()
        //    {
        //        // Arrange
        //        List<AddressDTO> addresses = new List<AddressDTO>();

        //        // Act
        //        ActualValueDelegate<CreateCompanyCommand> createCompanyCommandDelegate = () => new CreateCompanyCommand("Endava", addresses, DateTime.Now, false, 8000);

        //        // Assert
        //        Assert.That(createCompanyCommandDelegate, Throws.TypeOf<ArgumentException>());
        //    }
        //}
    }
}
