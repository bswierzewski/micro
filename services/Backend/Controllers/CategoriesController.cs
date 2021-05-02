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
    public class CategoriesController : ControllerBase
    {
        private readonly IRepository<Category> _repo;
        private readonly IMapper _mapper;

        public CategoriesController(IMapper mapper, IRepository<Category> repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategory(int id)
        {
            var result = await _repo.GetById(id, includes: new List<Expression<Func<Category, object>>>
            {
                x => x.Components
            });

            return _mapper.Map<CategoryDto>(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> GetCategories()
        {
            var results = await _repo.Get(includes: new List<Expression<Func<Category, object>>>
            {
                x => x.Components
            });

            return _mapper.Map<List<CategoryDto>>(results);
        }
    }
}
