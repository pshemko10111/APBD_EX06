using APBDEX06.DTOs;
using APBDEX06.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBDEX06.Controllers
{
    public class PrescriptionController : Controller
    {
        private readonly PrescriptionService _service;

        public PrescriptionController(PrescriptionService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddNewPrescriptionAsync([FromBody] NewPrescriptionRequestDTO requestDTO)
        {
            try
            {
                await _service.AddNewPrescriptionAsync(requestDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
