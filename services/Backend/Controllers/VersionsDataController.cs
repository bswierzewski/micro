using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    public class VersionsDataController : ControllerBaseEntity<VersionData>
    {

        public VersionsDataController(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork) { }

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
