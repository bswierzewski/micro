using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KindsController : ControllerBase
    {
        private readonly IRepository<Kind> _repo;
        private readonly IMapper _mapper;

        public KindsController(IMapper mapper, IRepository<Kind> repo)
        {
            _mapper = mapper;
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
