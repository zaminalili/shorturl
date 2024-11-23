using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shorturl.API.Models.Dtos;
using shorturl.API.Services.Abstract;

namespace shorturl.API.Controllers
{
    [Route("api/shorten")]
    [ApiController]
    public class UrlController(IUrlService urlService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUrlDto dto)
        {
            var urlDetail = await urlService.CreateShortUrl(dto.Url);

            return CreatedAtAction(nameof(Get), new { shortCode = urlDetail.ShortCode }, urlDetail);
        }

        [HttpGet("{shortCode}")]
        public async Task<IActionResult> Get([FromRoute] string shortCode)
        {
            var urlDetail = await urlService.GetShortUrl(shortCode);

            if (urlDetail == null)
                return NotFound();

            return Ok(urlDetail);
        }

        [HttpPut("{shortCode}")]
        public async Task<IActionResult> Update([FromRoute] string shortCode, UpdateUrlDto dto)
        {
            var urlDetail = await urlService.UpdateShortUrl(shortCode, dto.Url);

            if (urlDetail == null)
                return NotFound();

            return Ok(urlDetail);
        }

        [HttpDelete("{shortCode}")]
        public async Task<IActionResult> Delete([FromRoute] string shortCode)
        {
            var isDeleted =  await urlService.DeleteShortUrl(shortCode);

            if (!isDeleted)
                return NotFound();
            
            return NoContent();
        }
    }
}
