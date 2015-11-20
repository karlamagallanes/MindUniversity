using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BL = MindEval.FiveSquare.Business;
using DTO = MindEval.FiveSquare.Common;

namespace MindEval.FiveSquare.App.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
        private BL.User _user = new  BL.User();

        [ActionName("Get")]
        [HttpGet]
        public IHttpActionResult Register(int i)
        {
            return Ok(_user.GetUser(i));
        }


        // POST api/User/Logout
        [Route("Register")]
        public IHttpActionResult Register(DTO.User userModel)
        {
            try
            {
                _user.Register(userModel);
                return Ok();
            }
            catch (DTO.MamalonaException mamalon)
            {
                return new MamalonResult(HttpStatusCode.BadRequest, mamalon.Message);
            }
        }

        //POST api/User/Login
        [Route("Login")]
        public IHttpActionResult Login(string email, string password)
        {
            try
            {
                string token = _user.Login(email, password);
                return Ok(token);
            }
            catch (DTO.MamalonaException mamalon)
            {
                return new MamalonResult(HttpStatusCode.NotFound, mamalon.Message);
            }
            
        }

        // POST api/User/Logout
        [Route("Logout")]
        public IHttpActionResult Logout()
        {            
            return Ok();
        }
    }
}