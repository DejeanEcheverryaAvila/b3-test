using Xunit;
using CDB_B3.Interfaces;
using CDB_B3.Models;
using CDB_B3.Services;

namespace CDB_B3.Tests.Services
{
    public class CustomCdbCalculatorServiceTests
    {
        /// <summary>
        /// Tests that the CalculateCDB method of the CustomCDBCalculatorService 
        /// throws a NotImplementedException.
        /// </summary>
        [Fact]
        public void CalculateCDB_ShouldThrowNotImplementedException()
        {
            // Arrange
            ICdbCalculator calculator = new CustomCdbCalculatorService();
            
            var calculationRequest = new CdbCalculationRequestModel
            {
                MoneyToInvest = 1000.0m,
                MonthsToRedemption = 12
            };

            // Act and Assert
            Assert.Throws<NotImplementedException>(() => calculator.CalculateCDB(calculationRequest));
        }
    }
}
