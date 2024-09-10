using CDB_B3.Interfaces;
using CDB_B3.Models;

namespace CDB_B3.Services
{
    /// <summary>
    /// Represents a service that calculates the gross and net investment values for a CDB investment with simple interest.
    /// </summary>
    public class SimpleCdbCalculatorService : ICdbCalculator
    {
        private readonly InvestmentIncomeTaxService _taxService;
        
        /// <summary>
        /// Represents a simple calculator service for calculating CDB investments.
        /// </summary>
        /// <remarks>
        /// This service uses the provided <see cref="InvestmentIncomeTaxService"/> to calculate the income tax on the investment.
        /// </remarks>
        public SimpleCdbCalculatorService(InvestmentIncomeTaxService taxService)
        {
            _taxService = taxService;
        }

        /// <summary>
        /// Calculates the gross and net investment values for a CDB investment based on the given calculation request.
        /// </summary>
        /// <param name="calculationRequest">The calculation request containing the investment details.</param>
        /// <returns>A CDBCalculationResultModel object containing the gross and net investment values.</returns>
        public CdbCalculationResultModel CalculateCDB(CdbCalculationRequestModel calculationRequest)
        {
            // Just for the sake of the test I'm hardcoding the values here
            decimal cdi = 0.009m; // 0.9%
            decimal tb = 1.08m;  // 108%

            // The initial value is equal to the final value
            decimal initialValue = calculationRequest.MoneyToInvest;
            decimal finalValue = initialValue;

            // Loop to calculate monthly earnings with reinvestment
            for (int i = 0; i < calculationRequest.MonthsToRedemption; i++)
            {
                // Monthly earnings calculation
                decimal monthlyEarnings = finalValue * (cdi * tb);

                // Add the earnings to the final value and update the initial value
                finalValue += monthlyEarnings;
            }

            // Calculate income tax on earnings
            decimal incomeTax = _taxService.CalculateTax(finalValue - initialValue, calculationRequest.MonthsToRedemption);
            
            // Truncate the values to 2 decimal places
            decimal grossInvestment = decimal.Truncate(finalValue * 100) / 100;
            decimal netInvestment = decimal.Truncate((finalValue - incomeTax) * 100) / 100;

            // Create and return the response object with the values
            var response = new CdbCalculationResultModel
            {
                GrossInvestment = grossInvestment,
                NetInvestment = netInvestment
            };

            return response;
        }
    }
}
