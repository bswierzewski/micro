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
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public KindsController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetKind(int id)
        {
            var result = await _unitOfWork.Repository<Kind>().GetById(id);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetKinds()
        {
            var results = await _unitOfWork.Repository<Kind>().Get();

            return Ok(results);
        }
    }
}
