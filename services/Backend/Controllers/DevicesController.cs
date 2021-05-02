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
    public class DevicesController : ControllerBase
    {
        private readonly IRepository<Device> _repo;
        private readonly IMapper _mapper;

        public DevicesController(IMapper mapper, IRepository<Device> repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DeviceDto>> GetDevice(int id)
        {
            var result = await _repo.GetById(id);

            return _mapper.Map<DeviceDto>(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<DeviceDto>>> GetDevices()
        {
            var results = await _repo.Get();

            return _mapper.Map<List<DeviceDto>>(results);
        }
    }
}
