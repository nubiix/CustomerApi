using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Customer.DTO.Models;
using Customer.DTO.Models.Constants;
using Customer.DTO.Repository.Service.Interface;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CustomerAPi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [AllowAnonymous]
    public class UserController : ControllerBase
    {
        public IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("{clientId}/{clientSecret}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetTokens(string clientId, string clientSecret)
        {
            try
            {
                var client = new HttpClient();
                var result = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest()
                {
                    Address=TokenConstants.TokenUrl,
                    ClientId = clientId,
                    ClientSecret = clientSecret,
                    Scope = TokenConstants.Scope
                });

                if (result != null)
                {
                    return Ok(JsonConvert.SerializeObject(result));
                }
                else
                {
                    return BadRequest(result);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500,e);
            }
        }        
        [HttpGet]
        public IActionResult GetCustomers()
        {
            try
            {
                var result = _userService.GetUsers(Roles.Customer);
                if (result != null && result.Any())
                {
                    return Ok(JsonConvert.SerializeObject(result));
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
        [HttpGet("{id}")]
        public IActionResult GetCustomerInfoById(string id)
        {
            try
            {
                var result = _userService.GetCustomerInfoById(id);
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
        public IActionResult CreateNewCustomer([FromBody] UserRequest user)
        {
            try
            {
                if(string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Surname))
                {
                    return BadRequest("Name and Surname must be sended.");
                }
                var result = _userService.CreateNewCustomer(new User()
                {
                    Name = user.Name,
                    Surname = user.Surname,
                    PhotoBase64 = user.PhotoBase64,
                    Role = Roles.Customer,
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
        public IActionResult UpdateCustomer([FromBody] UserRequest user)
        {
            try
            {
                var result = _userService.UpdateCustomer(new User()
                {
                    Name = user.Name,
                    Surname = user.Surname,
                    PhotoBase64 = user.PhotoBase64,
                    Role = Roles.Customer,
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
        public IActionResult RemoveCustomer(string id)
        {
            try
            {
                var result = _userService.RemoveCustomer(id, Roles.Customer);
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
