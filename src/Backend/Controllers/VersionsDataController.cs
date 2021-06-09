using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class VersionsDataController : ControllerBaseEntity<VersionData>
    {

        public VersionsDataController(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork) { }

        [HttpGet("{id}")]
        public IActionResult GetVersionData(int id)
        {
            var result = _unitOfWork.Repository<VersionData>().GetById(id);

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetVersionsData()
        {
            var results = _unitOfWork.Repository<VersionData>().Get();

            return Ok(results);
        }
    }
}
