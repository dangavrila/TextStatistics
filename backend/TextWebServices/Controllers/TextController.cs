using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TextWebServices.Models;
using TextWebServices.Repository;

namespace TextWebServices.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
    [ApiController]
    public class TextController : ControllerBase
    {
	    private readonly IMapper _mapper;
	    private readonly ITextsCollectionsRepository _textsRepository;

		public TextController(IMapper mapper, ITextsCollectionsRepository textsRepository)
		{
			_mapper = mapper;
			_textsRepository = textsRepository;
		}

	    [HttpPost]
	    [ProducesResponseType(typeof(TextItem), StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> PostAsync([FromBody]TextItem textItem)
	    {
		    await _textsRepository.InsertAsync(textItem, CancellationToken.None);

		    return CreatedAtAction("PostAsync", new {id = textItem.Id}, textItem);
	    }

		[HttpGet("{id}")]
		[ProducesResponseType(typeof(TextItem), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetItemText(string id)
		{
			var item = await _textsRepository.GetTextItemAsync(id, CancellationToken.None);

			return Ok(item);
		}
	}
}