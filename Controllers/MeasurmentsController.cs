using Microsoft.AspNetCore.Mvc;
using TempAPI.DBContext;
using TempAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TempAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurmentsController : ControllerBase
    {
        private MeasurementService _measurementService;

        public MeasurmentsController(TempContext tempContext)
        {
            _measurementService = new MeasurementService(tempContext);
        }

        // GET: api/<Measurments>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_measurementService.Get());
        }

        // GET api/<Measurments>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_measurementService.GetById(id));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }           
        }

        // POST api/<Measurments>
        [HttpPost]
        public IActionResult Post([FromBody] Measurment measurement)
        {
            try
            {
                Measurment createdMeasurement = _measurementService.Create(measurement);
                return CreatedAtAction(nameof(Get), new { id = createdMeasurement.Id }, createdMeasurement);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<Measurments>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _measurementService.Delete(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
