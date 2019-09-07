using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TextWebServices.Models;

namespace TextWebServices.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
    [ApiController]
    public class TextController : ControllerBase
    {
	    [HttpPost]
	    public void Post([FromBody]TextItem textItem)
	    {

	    }
	}
}