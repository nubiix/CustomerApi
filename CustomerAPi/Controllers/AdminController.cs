using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer.DTO.Models.Constants;
using Customer.DTO.Repository.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerAPi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        public IUserService _userService;
        public AdminController(IUserService userService)
        {
            _userService = userService;
        }      
        [HttpGet]
        public IActionResult GetUsers()
        {
            try
            {
                var result = _userService.GetUsers(Roles.User);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    //TODO
                    return NotFound(result);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500,e);
            }
        }        
        [HttpGet]
        public IActionResult CreateNewUser([FromQuery] string name, [FromQuery] string surname, [FromQuery] string photoBase64, [FromQuery] string user)
        {
            try
            {
                var result = _userService.CreateNewCustomer(new Customer.DTO.Models.User()
                {
                    Name = name,
                    Surname = surname,
                    PhotoBase64 = photoBase64,
                    Role = Customer.DTO.Models.Constants.Roles.User,
                    UserCreator = user,
                    UserLastModified = user
                });
                if (result != 0)
                {
                    return Ok(result);
                }
                else
                {
                    //TODO
                    return NotFound(result);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500,e);
            }
        }
        [HttpGet]
        public IActionResult UpdateUser([FromQuery] string name, [FromQuery] string surname, [FromQuery] string photoBase64, [FromQuery] string user)
        {
            try
            {
                var result = _userService.UpdateCustomer(new Customer.DTO.Models.User()
                {
                    Name = name,
                    Surname = surname,
                    PhotoBase64 = photoBase64,
                    Role = Customer.DTO.Models.Constants.Roles.User,
                    UserCreator = user,
                    UserLastModified = user
                });
                if (result != 0)
                {
                    return Ok(result);
                }
                else
                {
                    //TODO
                    return NotFound(result);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500,e);
            }
        }
        [HttpGet("{id}")]
        public IActionResult RemoveCustomer(string id)
        {
            try
            {
                var result = _userService.RemoveCustomer(id, Roles.User);
                if (result != 0)
                {
                    return Ok(result);
                }
                else
                {
                    //TODO
                    return NotFound(result);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500,e);
            }
        }

        [HttpGet("{id}")]
        // GET: UserController/Delete/5
        public IActionResult SetAdmin(string id)
        {
            try
            {
                var result = _userService.SetAdmin(id);
                if (result != 0)
                {
                    return Ok(result);
                }
                else
                {
                    //TODO
                    return NotFound(result);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500,e);
            }
        }
    }
}

