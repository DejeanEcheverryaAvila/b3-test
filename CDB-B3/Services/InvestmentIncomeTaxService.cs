namespace CDB_B3.Services
{
    /// <summary>
    /// Calculates the income tax for an investment based on the earnings and the investment period.
    /// </summary>
    public class InvestmentIncomeTaxService
    {
        /// <summary>
        /// Calculates the income tax for an investment based on the earnings and the investment period.
        /// </summary>
        /// <param name="earnings">The earnings from the investment.</param>
        /// <param name="monthsToRedemption">The number of months until the investment is redeemed.</param>
        /// <returns>The income tax for the investment.</returns>
        public decimal CalculateTax(decimal earnings, int monthsToRedemption)
        {
            // Determine the tax rate based on the investment period
            decimal taxRate = GetTaxRate(monthsToRedemption);

            // Calculate income tax
            decimal tax = earnings * taxRate;

            return tax;
        }

        /// <summary>
        /// Calculates the tax rate based on the number of months.
        /// </summary>
        /// <param name="months">The number of months.</param>
        /// <returns>The tax rate as a decimal.</returns>
        public decimal GetTaxRate(int months)
        {
            if (months <= 6)
            {
                return 0.225m; // Up to 6 months: 22.5%
            }
            else if (months <= 12)
            {
                return 0.20m; // Up to 12 months: 20%
            }
            else if (months <= 24)
            {
                return 0.175m; // Up to 24 months: 17.5%
            }
            else
            {
                return 0.15m; // Over 24 months: 15%
            }
        }
    }

}
