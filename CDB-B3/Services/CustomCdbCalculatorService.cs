using CDB_B3.Interfaces;
using CDB_B3.Models;

namespace CDB_B3.Services
{
    /// <summary>
    /// Represents a custom implementation of the ICdbCalculator interface.
    /// </summary>
    public class CustomCdbCalculatorService : ICdbCalculator
    {
      
        /// <summary>
        /// Calculates the CDB (Certificate of Deposit) based on the provided calculation request.
        /// </summary>
        /// <param name="calculationRequest">The calculation request containing the necessary parameters.</param>
        /// <returns>The result of the CDB calculation.</returns>
        public CdbCalculationResultModel CalculateCDB(CdbCalculationRequestModel calculationRequest)
        {
            throw new NotImplementedException();
        }
    }
}
