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
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public VersionsDataController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVersionData(int id)
        {
            var result = await _unitOfWork.Repository<VersionData>().GetById(id);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetVersionsData()
        {
            var results = await _unitOfWork.Repository<VersionData>().Get();

            return Ok(results);
        }
    }
}
