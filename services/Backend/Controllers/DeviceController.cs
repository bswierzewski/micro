using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeviceController : ControllerBase
    {
        private readonly IRepository<Device> _repo;

        public DeviceController(IRepository<Device> repo)
        {
            _repo = repo;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDevice(int id)
        {
            var result = await _repo.GetById(id);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetDevices()
        {
            var results = await _repo.Get();

            return Ok(results);
        }
    }
}
