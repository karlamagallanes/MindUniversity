using System.Collections.Generic;
using System.Web.Http;
using BL = MindEval.FiveSquare.Business;
using DTO = MindEval.FiveSquare.Common;
using System;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;

using System.Web.Http.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;


namespace MindEval.FiveSquare.App.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
        private const string LocalLoginProvider = "Local";
        private BL.User _user = new BL.User();

        // POST api/User/Logout
        [Route("Register")]
        public IHttpActionResult Register(DTO.User userModel)
        {
            try
            {
                _user.Register(userModel);
                return Ok();
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.StatusCode = 401;
            }
        }


        // GET: api/User/5
        public IHttpActionResult Get(int id)
        {
            DTO.User user = _user.GetUser(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        //// POST api/User/Logout
        //[Route("Logout")]
        //public IHttpActionResult Logout()
        //{
        //    Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
        //    return Ok();
        //}

    }
}