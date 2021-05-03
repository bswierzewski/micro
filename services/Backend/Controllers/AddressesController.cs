using AutoMapper;
using Backend.Dtos;
using Backend.Wrappers;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    public class AddressesController : ControllerBaseEntity<Address>
    {
        public AddressesController(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork) { }

        [HttpGet("{id}")]
        public async Task<ActionResult<Response<Address>>> GetAddress(int id)
        {
            var result = await _unitOfWork.Repository<Address>().GetById(id);

            return new Response<Address>(result);
        }

        [HttpGet]
        public async Task<ActionResult<Response<IEnumerable<Address>>>> GetAddresses()
        {
            var results = await _unitOfWork.Repository<Address>().Get();

            return new Response<IEnumerable<Address>>(results);
        }

        [HttpPost]
        public async Task<ActionResult<Response<Address>>> CreateAddress(AddressToCreateDto addressDto)
        {
            var address = _mapper.Map<Address>(addressDto);

            _unitOfWork.Repository<Address>().Add(address);

            await _unitOfWork.Complete();

            return new Response<Address>(address);
        }
    }
}
