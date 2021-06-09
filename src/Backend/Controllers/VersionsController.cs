using AutoMapper;
using Backend.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Backend.Controllers
{
    public class VersionsController : ControllerBaseEntity<Version>
    {

        public VersionsController(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork) { }

        [HttpGet("{id}")]
        public ActionResult<VersionDto> GetVersion(int id)
        {
            var result = _unitOfWork.Repository<Version>().GetById(id);

            return _mapper.Map<VersionDto>(result);
        }

        [HttpGet]
        public ActionResult<List<VersionDto>> GetVersions()
        {
            var results = _unitOfWork.Repository<Version>().Get();

            return _mapper.Map<List<VersionDto>>(results);
        }
    }
}
