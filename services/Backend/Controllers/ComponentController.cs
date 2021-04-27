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
    public class ComponentController : ControllerBase
    {
        private readonly IRepository<Component> _repo;

        public ComponentController(IRepository<Component> repo)
        {
            _repo = repo;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetComponent(int id)
        {
            var result = await _repo.GetById(id);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetComponents()
        {
            var results = await _repo.Get(includes: new List<Expression<Func<Component, object>>>()
            {
            });

            return Ok(results);
        }
    }
}
