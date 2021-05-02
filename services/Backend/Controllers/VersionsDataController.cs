using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VersionsDataController : ControllerBase
    {
        private readonly IRepository<VersionData> _repo;
        private readonly IMapper _mapper;

        public VersionsDataController(IMapper mapper, IRepository<VersionData> repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVersionData(int id)
        {
            var result = await _repo.GetById(id);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetVersionsData()
        {
            var results = await _repo.Get();

            return Ok(results);
        }
    }
}
