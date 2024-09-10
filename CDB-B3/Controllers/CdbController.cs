using CDB_B3.Interfaces;
using CDB_B3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CDB_B3.Controllers
{
    /// <summary>
    /// Controller for Certificate of Deposit (CDB) calculations.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for calculating the CDB based on the provided input.
    /// </remarks>
    [Route("api/v{version:apiVersion}/cdb")]
    [ApiController]
    [ApiVersion("1.0")]
    public class CdbController : ControllerBase
    {
        private readonly ICdbCalculator _cdbCalculator;

        /// <summary>
        /// Initializes a new instance of the <see cref="CdbController"/> class.
        /// </summary>
        /// <param name="cdbCalculator">The CDB calculator.</param>
        public CdbController(ICdbCalculator cdbCalculator)
        {
            _cdbCalculator = cdbCalculator;
        }

        /// <summary>
        /// Calculates the CDB.
        /// </summary>
        /// <remarks>
        /// Calculate the Certificate of Deposit (CDB) based on the provided input.
        /// </remarks>
        /// <param name="calculationRequest">The CDB calculation request.</param>
        /// <returns>Returns the CDB calculation result.</returns>
        /// <response code="200">Returns the CDB calculation result.</response>
        /// <response code="400">If the request is invalid or missing required fields.</response>
        [HttpPost]
        [ProducesResponseType(typeof(CdbCalculationResultModel), 200)]
        [ProducesResponseType(400)]
        public IActionResult CalculateCDB(CdbCalculationRequestModel calculationRequest)
        {
            var response = _cdbCalculator.CalculateCDB(calculationRequest);
            return Ok(response);
        }
    }

}
