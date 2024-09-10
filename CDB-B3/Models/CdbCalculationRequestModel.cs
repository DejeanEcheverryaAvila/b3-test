using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CDB_B3.Models
{
    /// <summary>
    /// Represents a request model for calculating CDB investments.
    /// </summary>
    public class CdbCalculationRequestModel
    {
        /// <summary>
        /// The amount of money to invest in the CDB.
        /// </summary>
        [Required(ErrorMessage = "The MoneyToInvest field is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "The MoneyToInvest field must be a positive number.")]
        [DefaultValue(0.01)]
        public decimal MoneyToInvest { get; set; }

        /// <summary>
        /// The number of months until the CDB reaches maturity.
        /// </summary>
        [Required(ErrorMessage = "The MonthsToRedemption field is required.")]
        [Range(2, int.MaxValue, ErrorMessage = "The MonthsToRedemption field must be a positive integer greater than 1.")]
        [DefaultValue(2)]
        public int MonthsToRedemption { get; set; }
    }
}
