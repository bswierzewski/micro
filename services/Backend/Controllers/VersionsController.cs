using AutoMapper;
using Backend.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VersionsController : ControllerBase
    {
        private readonly IRepository<Version> _repo;
        private readonly IMapper _mapper;

        public VersionsController(IMapper mapper, IRepository<Version> repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VersionDto>> GetVersion(int id)
        {
            var result = await _repo.GetById(id);

            return _mapper.Map<VersionDto>(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<VersionDto>>> GetVersions()
        {
            var results = await _repo.Get();

            return _mapper.Map<List<VersionDto>>(results);
        }
    }
}
