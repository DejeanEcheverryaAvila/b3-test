using CDB_B3.Interfaces;
using CDB_B3.Models;
using CDB_B3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDB_B3.Tests.Services
{
    public class SimpleCdbCalculatorServiceTests
    {
        /// <summary>
        /// Tests the CalculateCDB method of the SimpleCDBCalculatorService 
        /// class to ensure it returns the correct result.
        /// </summary>
        [Fact]
        public void CalculateCDB_ShouldReturnCorrectResult()
        {
            // Arrange
            var taxService = new InvestmentIncomeTaxService();
            ICdbCalculator calculator = new SimpleCdbCalculatorService(taxService);

            // Set the calculation request
            var calculationRequest = new CdbCalculationRequestModel
            {
                MoneyToInvest = 1000.0m,
                MonthsToRedemption = 12
            };

            // Act
            var result = calculator.CalculateCDB(calculationRequest);

            // Assert
            Assert.NotNull(result);
            #pragma warning disable S2589
            // S2589 temporarily disabled because we are testing the response and not the calculation itself, 
            // so we are not interested in the actual values of the calculation, but in the response.
            Assert.Equal(1123.08m, result?.GrossInvestment);
            Assert.Equal(1098.46m, result?.NetInvestment);
            #pragma warning restore S2589
        }
    }
}
