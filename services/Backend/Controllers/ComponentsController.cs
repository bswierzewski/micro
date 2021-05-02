using AutoMapper;
using Backend.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComponentsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ComponentsController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ComponentDto>> GetComponent(int id)
        {
            var result = await _unitOfWork.Repository<Component>().GetById(id);

            return _mapper.Map<ComponentDto>(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<ComponentDto>>> GetComponents()
        {
            var results = await _unitOfWork.Repository<Component>().Get();

            return _mapper.Map<List<ComponentDto>>(results);
        }
    }
}
