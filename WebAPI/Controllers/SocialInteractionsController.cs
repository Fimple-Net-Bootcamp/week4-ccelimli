using Business.Abstracts;
using Entity.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialInteractionsController : ControllerBase
    {

        ISocialInteractionService _socialInteractionService;

        public SocialInteractionsController(ISocialInteractionService socialInteractionService)
        {
            this._socialInteractionService = socialInteractionService;
        }

        [HttpPost("add")]
        public IActionResult Add(AddSocialInteractionRequest addSocialInteractionRequest)
        {
            var Result = _socialInteractionService.Add(addSocialInteractionRequest);
            if (Result.Success)
            {
                return Ok(Result);
            }
            return BadRequest(Result);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var result = _socialInteractionService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var Result = _socialInteractionService.GetAll();
            if (Result.Success)
            {
                return Ok(Result);
            }
            return BadRequest(Result);
        }

        [HttpGet("getbyid/{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var Result = _socialInteractionService.GetById(id);
            if (Result.Success)
            {
                return Ok(Result);
            }
            return BadRequest(Result);
        }

        [HttpPut("update")]
        public IActionResult Update(UpdateSocialInteractionRequest updateSocialInteractionRequest)
        {
            var Result = _socialInteractionService.Update(updateSocialInteractionRequest);
            if (Result.Success)
            {
                return Ok(Result);
            }
            return BadRequest(Result);
        }
    }
}
