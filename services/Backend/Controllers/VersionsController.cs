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
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public VersionsController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VersionDto>> GetVersion(int id)
        {
            var result = await _unitOfWork.Repository<Version>().GetById(id);

            return _mapper.Map<VersionDto>(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<VersionDto>>> GetVersions()
        {
            var results = await _unitOfWork.Repository<Version>().Get();

            return _mapper.Map<List<VersionDto>>(results);
        }
    }
}
