using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KindController : ControllerBase
    {
        private readonly IRepository<Kind> _repo;

        public KindController(IRepository<Kind> repo)
        {
            _repo = repo;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetKind(int id)
        {
            var result = await _repo.GetById(id);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetKinds()
        {
            var results = await _repo.Get();

            return Ok(results);
        }
    }
}
