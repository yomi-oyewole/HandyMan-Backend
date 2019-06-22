using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HandyManAPI.DataContext;
using HandyManAPI.Helper.Security;
using HandyManAPI.Models;
using HandyManAPI.Persistence;
using HandyManAPI.Persistence.Repositories;


namespace HandyManAPI.Controllers
{
    public class LoginController : ApiController
    {
        private readonly HandyManContext _context;
  
        public LoginController()
        {
            _context = new HandyManContext();
       
        }

        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult UserLogin(Login login)
        {
            User user;
            if (string.IsNullOrEmpty(login.Email) || string.IsNullOrEmpty(login.Password))
                return BadRequest("email or password required");

            try
            {
                using (var unitOfWork = new UnitOfWork(_context))
                {
                    user = unitOfWork.Login.Authenticate(login.Email, login.Password);
                     
                    if (user == null)
                        return Unauthorized();

                    unitOfWork.Session.CreateSession(user);
                    
                }
                
            }
            catch(Exception e)
            {
                return BadRequest();
            }

            return Ok(user);

        }

        [HttpGet]
        [JwtAuthentication]
        public string Get()
        {
            return "Hello from Code-Adda.com";
        }
    }
}
