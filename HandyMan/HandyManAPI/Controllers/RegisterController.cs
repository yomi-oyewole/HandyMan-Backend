using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HandyManAPI.DataContext;
using HandyManAPI.Models;
using HandyManAPI.Persistence;
using HandyManAPI.Persistence.Repositories;

namespace HandyManAPI.Controllers
{
    public class RegisterController : ApiController
    {
        private readonly HandyManContext _context;


        public RegisterController()
        {
           _context = new HandyManContext();
           
        }

        [HttpPost]
        public IHttpActionResult Create(User user)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            using (var unit = new UnitOfWork(_context))
            {
                if (string.IsNullOrWhiteSpace(user.Password))
                    return BadRequest("Invalid Password");
                if (unit.Users.Any(x => x.Email == user.Email))
                    return BadRequest($"Username: {user.Email} is already taken");

                unit.Users.Create(user);
                //unit.Complete();
            }

            return Created(new Uri(Request.RequestUri + "/" + user.UserId), user);
        }


    }
}
