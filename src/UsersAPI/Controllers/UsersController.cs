using AutoMapper;
using Core.Contracts;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using UsersAPI.DTOs;

namespace UsersAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _service;
        private readonly IMapper _mapper;
        public UsersController(IUsersService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ReturnUserDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUsers([FromQuery] UserQueryParameters parameterss)
        {
            var userEntities = await _service.GetUsersAsync(parameterss.Name);

            var userDTOs = _mapper.Map<List<ReturnUserDTO>>(userEntities);
            return Ok(userDTOs);

        }
    }

}
