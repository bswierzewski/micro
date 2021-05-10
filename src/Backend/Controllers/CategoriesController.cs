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
    public class CategoriesController : ControllerBaseEntity<Category>
    {
        public CategoriesController(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork) { }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategory(int id)
        {
            var result = await _unitOfWork.Repository<Category>().GetById(id, includes: new List<Expression<Func<Category, object>>>
            {
                x => x.Components
            });

            return _mapper.Map<CategoryDto>(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> GetCategories()
        {
            var results = await _unitOfWork.Repository<Category>().Get(includes: new List<Expression<Func<Category, object>>>
            {
                x => x.Components
            });

            return _mapper.Map<List<CategoryDto>>(results);
        }
    }
}