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
        public IEnumerable<List<Measurment>> Get()
        {
            return _measurementService.Get();
        }

        // GET api/<Measurments>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Measurments>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<Measurments>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Measurments>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
