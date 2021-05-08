using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    public class KindsController : ControllerBaseEntity<Kind>
    {
        public KindsController(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork) { }

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
