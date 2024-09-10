using CDB_B3.Models;
using Xunit;

namespace CDB_B3.Tests.Models
{
    public class CdbCalculationResultModelTests
    {
        /// <summary>
        /// Tests the get and set properties of the GrossInvestment property 
        /// of the CDBCalculationResultModel class.
        /// </summary>
        [Fact]
        public void GrossInvestment_GetSetProperties()
        {
            // Arrange
            var result = new CdbCalculationResultModel();
            var expectedGrossInvestment = 1000.0m;

            // Act
            result.GrossInvestment = expectedGrossInvestment;
            var actualGrossInvestment = result.GrossInvestment;

            // Assert
            Assert.Equal(expectedGrossInvestment, actualGrossInvestment);
        }

        /// <summary>
        /// Tests the get and set properties of the NetInvestment property 
        /// in the CDBCalculationResultModel class.
        /// </summary>
        [Fact]
        public void NetInvestment_GetSetProperties()
        {
            // Arrange
            var result = new CdbCalculationResultModel();
            var expectedNetInvestment = 900.0m;

            // Act
            result.NetInvestment = expectedNetInvestment;
            var actualNetInvestment = result.NetInvestment;

            // Assert
            Assert.Equal(expectedNetInvestment, actualNetInvestment);
        }
    }
}
