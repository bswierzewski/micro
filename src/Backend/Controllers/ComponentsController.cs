using AutoMapper;
using Backend.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Backend.Controllers
{
    public class ComponentsController : ControllerBaseEntity<Component>
    {
        public ComponentsController(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork) { }

        [HttpGet("{id}")]
        public ActionResult<ComponentDto> GetComponent(int id)
        {
            var result = _unitOfWork.Repository<Component>().GetById(id);

            return _mapper.Map<ComponentDto>(result);
        }

        [HttpGet]
        public ActionResult<List<ComponentDto>> GetComponents()
        {
            var results = _unitOfWork.Repository<Component>().Get();

            return _mapper.Map<List<ComponentDto>>(results);
        }
    }
}
