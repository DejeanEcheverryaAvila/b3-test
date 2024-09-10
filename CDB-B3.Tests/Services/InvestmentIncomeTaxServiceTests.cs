using CDB_B3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDB_B3.Tests.Services
{
    public class InvestmentIncomeTaxServiceTests
    {
        /// <summary>
        /// Tests the CalculateTax method of the InvestmentIncomeTaxService class to 
        /// ensure that it calculates the tax correctly based on the earnings and
        /// months to redemption.
        /// </summary>
        /// <param name="earnings">The earnings to calculate the tax for.</param>
        /// <param name="monthsToRedemption">The number of months to redemption.</param>
        /// <param name="expectedTaxRate">The expected tax rate.</param>
        [Theory]
        [InlineData(1000, 6, 225)]  // Up to 6 months: 22.5%
        [InlineData(1000, 9, 200)]  // Up to 12 months: 20%
        [InlineData(1000, 18, 175)] // Up to 24 months: 17.5%
        [InlineData(1000, 30, 150)] // Over 24 months: 15%
        public void CalculateTax_ShouldCalculateTaxCorrectly(decimal earnings, int monthsToRedemption, decimal expectedTaxRate)
        {
            // Arrange
            var taxService = new InvestmentIncomeTaxService();

            // Act
            decimal tax = taxService.CalculateTax(earnings, monthsToRedemption);

            // Assert
            Assert.Equal(expectedTaxRate, tax);
        }

        /// <summary>
        /// Tests the GetTaxRate method of the InvestmentIncomeTaxService class to ensure 
        /// it returns the correct tax rate based on the number of months.
        /// </summary>
        /// <param name="months">The number of months to calculate the tax rate for.</param>
        /// <param name="expectedTaxRate">The expected tax rate for the given number of months.</param>
        [Theory]
        [InlineData(3, 0.225)]  // Up to 6 months: 22.5%
        [InlineData(9, 0.20)]   // Up to 12 months: 20%
        [InlineData(18, 0.175)] // Up to 24 months: 17.5%
        [InlineData(36, 0.15)]  // Over 24 months: 15%
        public void GetTaxRate_ShouldReturnCorrectTaxRate(int months, decimal expectedTaxRate)
        {
            // Arrange
            var taxService = new InvestmentIncomeTaxService();

            // Act
            decimal taxRate = taxService.GetTaxRate(months);

            // Assert
            Assert.Equal(expectedTaxRate, taxRate);
        }
    }
}
