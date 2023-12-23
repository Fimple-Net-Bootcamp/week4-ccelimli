using Business.Abstracts;
using Entity.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingMapPetsController : ControllerBase
    {
        ITrainingMapPetService _trainingMapPetService;

        public TrainingMapPetsController(ITrainingMapPetService trainingMapPetService)
        {
            _trainingMapPetService = trainingMapPetService;
        }

        [HttpPost("add")]
        public IActionResult Add(AddTrainingMapPetRequest addTrainingMapPetRequest)
        {
            _trainingMapPetService.Add(addTrainingMapPetRequest);
            return Ok();
        }


        [HttpGet("getdetail")]
        public IActionResult GetDetail()
        {
            var result = _trainingMapPetService.GetDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("getbyid/{petId}")]
        public IActionResult GetByPetId(int petId)
        {
            var result = _trainingMapPetService.GetByPetId(petId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
