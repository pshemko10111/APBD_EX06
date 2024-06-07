using APBDEX06.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBDEX06.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : Controller
    {
        private readonly PatientService _service;

        public PatientController(PatientService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientWithDetailsAsync(int id)
        {
            var patient = await _service.GetPatientWithDetailsAsync(id);
            if (patient == null) return NotFound();
            return Ok(patient);
        }
    }
}
