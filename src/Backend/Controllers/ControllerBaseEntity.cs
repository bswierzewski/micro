using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControllerBaseEntity<T> : ControllerBase where T : BaseEntity
    {
        internal readonly IUnitOfWork _unitOfWork;
        internal readonly IMapper _mapper;
        public ControllerBaseEntity(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpDelete("{id}")]
        public virtual ActionResult Delete(int id)
        {
            _unitOfWork.Repository<T>().Delete(id);

            _unitOfWork.Complete();

            return Ok();
        }
    }
}