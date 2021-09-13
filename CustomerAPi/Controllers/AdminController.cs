using System;
using System.Linq;
using Customer.DTO.Models;
using Customer.DTO.Models.Constants;
using Customer.DTO.Repository.Service.Interface;
using Microsoft.AspNetCore.Mvc;

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
                if (result != null && result.Any())
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound(result);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500,e);
            }
        }        
        [HttpPost]
        public IActionResult CreateNewUser([FromBody] UserRequest user)
        {
            try
            {
                var result = _userService.CreateNewCustomer(new User()
                {
                    Name = user.Name,
                    Surname = user.Surname,
                    PhotoBase64 = user.PhotoBase64,
                    Role = Customer.DTO.Models.Constants.Roles.User,
                    UserCreator = user.User,
                    UserLastModified = user.User
                });
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound(result);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500,e);
            }
        }
        [HttpPut]
        public IActionResult UpdateUser([FromBody] UserRequest user)
        {
            try
            {
                var result = _userService.UpdateCustomer(new User()
                {
                    Name = user.Name,
                    Surname = user.Surname,
                    PhotoBase64 = user.PhotoBase64,
                    Role = Customer.DTO.Models.Constants.Roles.User,
                    UserCreator = user.User,
                    UserLastModified = user.User
                });
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound(result);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500,e);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult RemoveUser(string id)
        {
            try
            {
                var result = _userService.RemoveCustomer(id, Roles.User);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound(result);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500,e);
            }
        }

        [HttpPatch("{id}")]
        public IActionResult SetAdmin(string id)
        {
            try
            {
                var result = _userService.SetAdmin(id);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
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

