using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TextServices.Interfaces;
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
	    private readonly ISortText _sortTextService;

		public TextController(IMapper mapper, ITextsCollectionsRepository textsRepository, ISortText sortText)
		{
			_mapper = mapper;
			_textsRepository = textsRepository;
			_sortTextService = sortText;
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

		[HttpPost]
		[ProducesResponseType(typeof(TextItem), StatusCodes.Status200OK)]
		public async Task<IActionResult> Sort([FromBody] SortTextInput sortTextInput)
		{
			TextItem responseObject = null;
			if (ModelState.IsValid)
			{
				if (sortTextInput.Option == SortOptionsEnum.ASC)
				{
					_sortTextService.SortTextAscending(sortTextInput.TextItem.Body, out var ascSortedText);
					responseObject = new TextItem()
					{
						Id = sortTextInput.TextItem.Id,
						Title = sortTextInput.TextItem.Title,
						Body = ascSortedText,
						Authors = sortTextInput.TextItem.Authors
					};

					await _textsRepository.InsertAsync(responseObject, CancellationToken.None);

					return Ok(responseObject);
				}

				if (sortTextInput.Option == SortOptionsEnum.DESC)
				{
					_sortTextService.SortTextDescending(sortTextInput.TextItem.Body, out var descSortedText);
					responseObject = new TextItem()
					{
						Id = sortTextInput.TextItem.Id,
						Title = sortTextInput.TextItem.Title,
						Body = descSortedText,
						Authors = sortTextInput.TextItem.Authors
					};

					await _textsRepository.InsertAsync(responseObject, CancellationToken.None);

					return Ok(responseObject);
				}
			}

			return BadRequest(ModelState);
		}
	}
}