using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Customer.DTO.Models.Constants;
using Customer.DTO.Repository.Service.Interface;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using static IdentityServer4.IdentityServerConstants;

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
        // GET: UserController/GetCustomers
        [HttpGet("{clientId}/{clientSecret}")]
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
                    //TODO
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
                if (result != null)
                {
                    return Ok(JsonConvert.SerializeObject(result));
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
        // GET: UserController/Create
        public IActionResult GetCustomerInfoById(string id)
        {
            try
            {
                var result = _userService.GetCustomerInfoById(id);
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
        public IActionResult CreateNewCustomer([FromQuery] string name, [FromQuery] string surname, [FromQuery] string photoBase64, [FromQuery] string user)
        {
            try
            {
                if(string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname))
                {
                    return BadRequest("Name and Surname must be sended.");
                }
                var result = _userService.CreateNewCustomer(new Customer.DTO.Models.User()
                {
                    Name = name,
                    Surname = surname,
                    PhotoBase64 = photoBase64,
                    Role = Customer.DTO.Models.Constants.Roles.Customer,
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
        // GET: UserController/Edit/5
        public IActionResult UpdateCustomer([FromQuery] string name, [FromQuery] string surname, [FromQuery] string photoBase64, [FromQuery] string user)
        {
            try
            {
                var result = _userService.UpdateCustomer(new Customer.DTO.Models.User()
                {
                    Name = name,
                    Surname = surname,
                    PhotoBase64 = photoBase64,
                    Role = Roles.Customer,
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
        // GET: UserController/Delete/5
        public IActionResult RemoveCustomer(string id)
        {
            try
            {
                var result = _userService.RemoveCustomer(id, Roles.Customer);
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
