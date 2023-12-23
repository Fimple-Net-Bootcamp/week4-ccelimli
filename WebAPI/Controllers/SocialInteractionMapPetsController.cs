using Business.Abstracts;
using Entity.Concretes;
using Entity.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SocialInteractionMapPetsController : ControllerBase
    {
        ISocialInteractionMapPetService _socialInteractionMapPetService;

        public SocialInteractionMapPetsController(ISocialInteractionMapPetService socialInteractionMapPetService)
        {
            _socialInteractionMapPetService = socialInteractionMapPetService;
        }

        [HttpPost("add")]
        public IActionResult Add(AddSocialInteractionMapPetRequest addSocialInteractionMapPetRequest)
        {
            _socialInteractionMapPetService.Add(addSocialInteractionMapPetRequest   );
            return Ok(); 
        }


        [HttpGet("getdetail")]
        public IActionResult GetDetail()
        {
            var result = _socialInteractionMapPetService.GetDetails();
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("getbyid/{petId}")]
        public IActionResult GetByPetId(int petId)
        {
            var result=_socialInteractionMapPetService.GetByPetId(petId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

    }
}
