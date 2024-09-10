using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using CDB_B3;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;
using CDB_B3.Models;
using System.Net;

namespace CDB_B3_Tests.Controllers 
{

    public class CdbControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public CdbControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        /// <summary>
        /// Tests the CalculateCDB method of the CDBController 
        /// and verifies that it returns an OK response.
        /// </summary>
        [Fact]
        public async Task CalculateCDB_ReturnsOkResponse()
        {
            // Arrange
            var client = _factory.CreateClient();

            /// <summary>
            /// Initializes a new instance of the <see cref="CdbCalculationRequestModel"/> class with default values for testing purposes.
            /// </summary>
            var calculationRequest = new CdbCalculationRequestModel
            {
                MoneyToInvest = 1000.0m,
                MonthsToRedemption = 12
            };

            // Act
            var response = await client.PostAsJsonAsync("/api/v1/cdb", calculationRequest);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        /// <summary>
        /// Tests the CalculateCDB method of the CDBController and 
        /// verifies that it returns the expected result.
        /// </summary>
        [Fact]
        public async Task CalculateCDB_ReturnsExpectedResult()
        {
            // Arrange
            var client = _factory.CreateClient();

            /// <summary>
            /// Initializes a new instance of the <see cref="CdbCalculationRequestModel"/> class with default values for testing purposes.
            /// </summary>
            var calculationRequest = new CdbCalculationRequestModel
            {
                MoneyToInvest = 1000.0m,
                MonthsToRedemption = 12
            };

            // Act
            var response = await client.PostAsJsonAsync("/api/v1/cdb", calculationRequest);

            // Assert
            // Let's check our response and make sure it has the values we
            // expect and taxes are applied as expected.
            var calculationResponse = await response.Content.ReadFromJsonAsync<CdbCalculationResultModel>();

            Assert.NotNull(calculationResponse);
            #pragma warning disable S2589
            // S2589 temporarily disabled because we are testing the response and not the calculation itself, 
            // so we are not interested in the actual values of the calculation, but in the response.
            Assert.Equal(1123.08m, calculationResponse?.GrossInvestment);
            Assert.Equal(1098.46m, calculationResponse?.NetInvestment);
            #pragma warning restore S2589
        }

        /// <summary>
        /// Tests the CalculateCDB method of the CDBController and verifies that it 
        /// returns an error response when the request is invalid.
        /// </summary>
        [Fact]
        public async Task CalculateCDB_ReturnsBadRequestResponse_WhenRequestIsInvalid()
        {
            // Arrange
            var client = _factory.CreateClient();

            /// <summary>
            /// Initializes a new instance of the <see cref="CdbCalculationRequestModel"/> class with default values for testing purposes.
            /// </summary>
            var calculationRequest = new CdbCalculationRequestModel
            {
                MoneyToInvest = 1000.0m,
                MonthsToRedemption = 0 // Invalid value
            };

            // Act
            var response = await client.PostAsJsonAsync("/api/v1/cdb", calculationRequest);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        /// <summary>
        /// Tests the CalculateCDB method of the CDBController and verifies that it 
        /// returns an error response when the request is missing required fields.
        /// </summary>
        [Fact]
        public async Task CalculateCDB_ReturnsBadRequestResponse_WhenRequestIsMissingRequiredFields()
        {
            // Arrange
            var client = _factory.CreateClient();

            /// <summary>
            /// Initializes a new instance of the <see cref="CdbCalculationRequestModel"/> class with default values for testing purposes and missing on purpose the second field.
            /// </summary>
            var calculationRequest = new CdbCalculationRequestModel
            {
                MoneyToInvest = 1000.0m
            };

            // Act
            var response = await client.PostAsJsonAsync("/api/v1/cdb", calculationRequest);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
