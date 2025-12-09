using Microsoft.AspNetCore.Mvc;
using Clinica.Application.Contract;
using Clinica.Application.Dtos.Dentist;

namespace Clinica.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DentistsController : ControllerBase
    {
        private readonly IDentistService _service;

        public DentistsController(IDentistService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok((await _service.GetAllAsync()).Data);

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await _service.GetByIdAsync(id);
            return res.Success ? Ok(res.Data) : NotFound(res.Message);
        }

        [HttpPost]
        public async Task<IActionResult> Post(DentistDto dto)
        {
            var res = await _service.CreateAsync(dto);
            return res.Success
                ? CreatedAtAction(nameof(Get), new { id = res.Data!.Id }, res.Data)
                : BadRequest(res.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, DentistDto dto)
        {
            var res = await _service.UpdateAsync(id, dto);
            return res.Success ? Ok(res.Data) : NotFound(res.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _service.DeleteAsync(id);
            return res.Success ? NoContent() : NotFound(res.Message);
        }
    }
}
