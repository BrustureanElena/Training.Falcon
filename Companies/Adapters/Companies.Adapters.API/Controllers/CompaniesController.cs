using System;
using System.Threading.Tasks;
using Api.Infrastructure.Hateoas.Response.ResourceMetadataEnrichment;
using Companies.Adapters.API.Models;
using Companies.Core.ApplicationServices.Companies.Commands.CreateCompany;
using Companies.Core.ApplicationServices.Companies.Exceptions;
using Companies.Core.ApplicationServices.Companies.Queries.ReadCompany;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Companies.Adapters.API.Controllers
{
    /// <summary>
    /// Companies Controller
    /// </summary>
    [ApiController]
    [Route("companies")]
    public class CompaniesController : ControllerBase
    {
        private readonly IMediator mediator;

        /// <summary>
        /// CompaniesController constructor
        /// </summary>
        /// <param name="mediator">An instance of IMediator.</param>
        public CompaniesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Retrieves a company identified by its unique identifier.
        /// </summary>
        /// <param name="companyId">Company Identifier</param>
        /// <returns>A company.</returns>
        [HttpGet]
        [Route("{companyId}", Name = "GetCompany")]
        [ProducesResponseType(typeof(CompanyResourceModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid companyId)
        {
            try
            {
                var query = new ReadCompanyQuery(companyId);
                var retrievedCompany = await mediator.Send(query);

                var retrievedCompanyModel = new CompanyResourceModel(retrievedCompany);
                retrievedCompanyModel.AddHypermediaLinks(this);

                return Ok(retrievedCompanyModel);
            }
            catch (NotFoundRequestException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Create a new Company
        /// </summary>
        /// <param name="company">Company</param>
        /// <returns>Returns the created Company.</returns>
        [HttpPost]
        [Route("company", Name = "AddCompany")]
        [ProducesResponseType(typeof(CompanyResourceModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CompanyResourceModel company)
        {
            if (company == null)
            {
                return BadRequest();
            }

            var command = new CreateCompanyCommand(company.CompanyName,
                (System.Collections.Generic.List<AddressResponse>)company.Addresses, company.RegistrationDate,
                company.IsBankrupt, company.NumberOfEmployees);
            var companyId = await mediator.Send(command);
            var query = new ReadCompanyQuery(companyId);

            var newCompany = await mediator.Send(query);
            var newCompanyModel = new CompanyResourceModel(newCompany);

            newCompanyModel.AddHypermediaLinks(this);

            return Created(
                new Uri(this.GetRouteBuilder().BuildRoute("AddCompany", new { id = newCompany.Id })),
                newCompanyModel);
        }
    }
}
