using Business.Abstracts;
using Entity.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TrainingsController : ControllerBase
    {
        ITrainingService _trainingService;

        public TrainingsController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }

        [HttpPost("add")]
        public IActionResult Add(AddTrainingRequest addTrainingRequest)
        {
            var Result = _trainingService.Add(addTrainingRequest);
            if (Result.Success)
            {
                return Ok(Result);
            }
            return BadRequest(Result);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var result = _trainingService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var Result = _trainingService.GetAll();
            if (Result.Success)
            {
                return Ok(Result);
            }
            return BadRequest(Result);
        }

        [HttpGet("getbyid/{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var Result = _trainingService.GetById(id);
            if (Result.Success)
            {
                return Ok(Result);
            }
            return BadRequest(Result);
        }

        [HttpPut("update")]
        public IActionResult Update(UpdateTrainingRequest updateTrainingRequest)
        {
            var Result = _trainingService.Update(updateTrainingRequest);
            if (Result.Success)
            {
                return Ok(Result);
            }
            return BadRequest(Result);
        }
}
}
