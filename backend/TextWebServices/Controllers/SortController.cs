using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TextServices.Interfaces;
using TextWebServices.Models;
using TextWebServices.Repository;

namespace TextWebServices.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class SortController : ControllerBase
    {
	    private readonly ISortText _sortTextService;
	    readonly ITextsCollectionsRepository _textsRepository;

		public SortController(ISortText sortText, ITextsCollectionsRepository textsRepository)
		{
			_sortTextService = sortText;
			_textsRepository = textsRepository;
		}

	    [HttpPost]
		public async Task<IActionResult> SortAsync([FromBody] SortTextInput sortTextInput)
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

				    return Content(responseObject.Body, "text/plain", Encoding.Unicode);
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

				    return Content(responseObject.Body, "text/plain", Encoding.Unicode);
			    }
		    }

		    return BadRequest(ModelState);
	    }
	}
}