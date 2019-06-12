using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HandyManAPI.DataContext;
using HandyManAPI.Models;
using HandyManAPI.Persistence;

namespace HandyManAPI.Controllers
{
    public class RegisterController : ApiController
    {

        public RegisterController()
        {
            
        }

        [HttpPost]
        public IHttpActionResult Create(User user)
        {
            using (var unit = new UnitOfWork(new HandyManContext()))
            {
                if (string.IsNullOrWhiteSpace(user.Password))
                    return BadRequest("Invalid Password");
                if (unit.Users.Any(x => x.Email == user.Email))
                    return BadRequest($"Username: {user.Email} is already taken");
                //user.UserId = "1";
                unit.Users.Create(user);
                //unit.Complete();
            }

            return Ok(user);
        }

    }
}
