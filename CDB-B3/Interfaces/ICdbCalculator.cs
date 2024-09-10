using CDB_B3.Models;

namespace CDB_B3.Interfaces
{
    /// <summary>
    /// Interface for calculating CDB (Certificate of Deposit) investments.
    /// </summary>
    public interface ICdbCalculator
    {
        /// <summary>
        /// Calculates the CDB investment based on the provided calculation request.
        /// </summary>
        /// <param name="calculationRequest">The calculation request containing the necessary information for the CDB investment calculation.</param>
        /// <returns>The result of the CDB investment calculation.</returns>
        CdbCalculationResultModel CalculateCDB(CdbCalculationRequestModel calculationRequest);
    }
}
