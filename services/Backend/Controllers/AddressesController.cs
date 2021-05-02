using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressesController : ControllerBase
    {
        private readonly IRepository<Address> _repo;
        private readonly IMapper _mapper;

        public AddressesController(IMapper mapper, IRepository<Address> repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddress(int id)
        {
            var result = await _repo.GetById(id);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAddresses()
        {
            var results = await _repo.Get();

            return Ok(results);
        }
    }
}
