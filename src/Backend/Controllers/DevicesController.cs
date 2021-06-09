using AutoMapper;
using Backend.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Backend.Controllers
{
    public class DevicesController : ControllerBaseEntity<Device>
    {
        public DevicesController(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork) { }

        [HttpGet("{id}")]
        public ActionResult<DeviceDto> GetDevice(int id)
        {
            var result = _unitOfWork.Repository<Device>().GetById(id);

            return _mapper.Map<DeviceDto>(result);
        }

        [HttpGet]
        public ActionResult<List<DeviceDto>> GetDevices()
        {
            var results = _unitOfWork.Repository<Device>().Get();

            return _mapper.Map<List<DeviceDto>>(results);
        }
    }
}
