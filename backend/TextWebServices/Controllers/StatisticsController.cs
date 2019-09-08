using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TextServices.Entities;
using TextServices.Interfaces;
using TextWebServices.Models;

namespace TextWebServices.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
	    private readonly IGenerateTextStatistics _generateTextStatistics;

	    public StatisticsController(IGenerateTextStatistics generateTextStatistics)
	    {
		    _generateTextStatistics = generateTextStatistics;
	    }

		[HttpPost]
		[ProducesResponseType(typeof(TextStatistics), StatusCodes.Status200OK)]
		public IActionResult PostAsync([FromBody] string input)
		{
			var result = _generateTextStatistics.GenerateStatistics(input);

			return Ok(result);
		}
    }
}