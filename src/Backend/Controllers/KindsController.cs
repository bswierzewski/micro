using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class KindsController : ControllerBaseEntity<Kind>
    {
        public KindsController(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork) { }

        [HttpGet("{id}")]
        public IActionResult GetKind(int id)
        {
            var result = _unitOfWork.Repository<Kind>().GetById(id);

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetKinds()
        {
            var results = _unitOfWork.Repository<Kind>().Get();

            return Ok(results);
        }
    }
}
