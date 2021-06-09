using AutoMapper;
using Backend.Dtos;
using Backend.Wrappers;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

namespace Backend.Controllers
{
    public class AddressesController : ControllerBaseEntity<Address>
    {
        public AddressesController(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork) { }

        [HttpGet("{id}")]
        public ActionResult<Response<Address>> GetAddress(int id)
        {
            var result = _unitOfWork.Repository<Address>().GetById(id);

            if (result == null)
                return NotFound(new ErrorResponse(HttpStatusCode.NotFound, "Addresses not found"));

            return Ok(new Response<Address>(result));
        }

        [HttpGet]
        public ActionResult<Response<IEnumerable<Address>>> GetAddresses()
        {
            var results = _unitOfWork.Repository<Address>().Get();

            return new Response<IEnumerable<Address>>(results);
        }

        [HttpPost]
        public ActionResult<Response<Address>> CreateAddress(AddressToCreateDto addressDto)
        {
            var address = _mapper.Map<Address>(addressDto);

            _unitOfWork.Repository<Address>().Add(address);

            _unitOfWork.Complete();

            return new Response<Address>(address);
        }
    }
}