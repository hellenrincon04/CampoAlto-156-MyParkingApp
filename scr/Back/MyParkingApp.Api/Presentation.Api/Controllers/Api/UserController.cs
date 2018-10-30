using System;
using System.Collections.Generic;
using Application.Main.Definition;
using Core.DataTransferObject;
using Core.Entities;
using Crosscutting.DependencyInjectionFactory;
using Microsoft.AspNetCore.Mvc;
using Presentation.Api.Models;

namespace Presentation.Api.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserAppService _userAppService;

        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        // GET: api/User
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var r = new BaseApiResponse();
            try
            {
                r = _userAppService.GetUserById(id);
                if (r.ActionCompleted)
                {
                    return Ok(r);
                }
                return BadRequest(r);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return Conflict(r);
            }
        }

        // POST: api/User
        [HttpPost]
        public IActionResult Post(RegisterUserModel model)
        {
            BaseApiResponse response = new BaseApiResponse();
            try
            {
                if (!ModelState.IsValid)
                {
                    BadRequest(ModelState);
                }
                response = _userAppService.RegisterUser(new User());
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                response.Message = e.InnerException != null ? e.InnerException.Message : e.Message;
                return Conflict(response);
            }
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
