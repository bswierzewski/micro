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
        private readonly IRepository<Component> _repo;
        private readonly IMapper _mapper;

        public ComponentsController(IMapper mapper, IRepository<Component> repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ComponentDto>> GetComponent(int id)
        {
            var result = await _repo.GetById(id);

            return _mapper.Map<ComponentDto>(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<ComponentDto>>> GetComponents()
        {
            var results = await _repo.Get();

            return _mapper.Map<List<ComponentDto>>(results);
        }
    }
}
