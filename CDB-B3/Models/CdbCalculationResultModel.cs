namespace CDB_B3.Models
{
    /// <summary>
    /// Represents the result of a CDB calculation, including the gross and net investment amounts.
    /// </summary>
    public class CdbCalculationResultModel
    {
        /// <summary>
        /// Gets or sets the gross investment amount.
        /// </summary>
        public decimal GrossInvestment { get; set; }
        /// <summary>
        /// Gets or sets the net investment amount.
        /// </summary>
        public decimal NetInvestment { get; set; }
    }
}
