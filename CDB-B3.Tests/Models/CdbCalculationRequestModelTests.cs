using CDB_B3.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace CDB_B3.Tests.Models
{
    public class CdbCalculationRequestModelTests
    {
       

        /// <summary>
        /// Tests that the MoneyToInvest property of the CDBCalculationRequestModel class 
        /// has a Range attribute that only allows positive numbers.
        /// </summary>
        /// <param name="value">The value to test.</param>
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void MoneyToInvest_ShouldHaveRangeAttribute(decimal value)
        {
            // Arrange
            var request = new CdbCalculationRequestModel
            {
                MoneyToInvest = value
            };

            // Act
            var result = ValidateModel(request);

            // Assert
            Assert.Contains("The MoneyToInvest field must be a positive number.", result);
        }

        /// <summary>
        /// Tests that the MonthsToRedemption property of the CDBCalculationRequestModel class 
        /// has a Range attribute. 
        /// </summary>
        /// <param name="value">The value to set the MonthsToRedemption property to.</param>
        [Theory]
        [InlineData(1)]
        [InlineData(0)]
        [InlineData(-1)]
        public void MonthsToRedemption_ShouldHaveRangeAttribute(int value)
        {
            // Arrange
            var request = new CdbCalculationRequestModel
            {
                MonthsToRedemption = value
            };

            // Act
            var result = ValidateModel(request);

            // Assert
            Assert.Contains("The MonthsToRedemption field must be a positive integer greater than 1.", result);
        }

        private static string[] ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, context, validationResults, true);

            var errorMessages = validationResults.Select(result => result.ErrorMessage).ToArray();

            return errorMessages!;
        }
    }
}
