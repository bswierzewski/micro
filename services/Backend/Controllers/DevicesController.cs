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
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DevicesController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DeviceDto>> GetDevice(int id)
        {
            var result = await _unitOfWork.Repository<Device>().GetById(id);

            return _mapper.Map<DeviceDto>(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<DeviceDto>>> GetDevices()
        {
            var results = await _unitOfWork.Repository<Device>().Get();

            return _mapper.Map<List<DeviceDto>>(results);
        }
    }
}
