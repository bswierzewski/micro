using AutoMapper;
using Backend.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    public class AddressesController : ControllerBaseEntity<Address>
    {
        public AddressesController(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork) { }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddress(int id)
        {
            var result = await _unitOfWork.Repository<Address>().GetById(id);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAddresses()
        {
            var results = await _unitOfWork.Repository<Address>().Get();

            return Ok(results);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress(AddressToCreateDto addressDto)
        {
            var address = _mapper.Map<Address>(addressDto);

            _unitOfWork.Repository<Address>().Add(address);

            await _unitOfWork.Complete();

            return Ok();
        }
    }
}
