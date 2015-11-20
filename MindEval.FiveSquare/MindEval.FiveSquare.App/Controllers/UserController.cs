using System.Net;
using System.Web.Http;
using BL = MindEval.FiveSquare.Business;
using DTO = MindEval.FiveSquare.Common;

namespace MindEval.FiveSquare.App.Controllers
{
    public class UserController : ApiController
    {
        private BL.IUser _user = new BL.User();
        

        [ActionName("Get")]
        public IHttpActionResult GetUser(int id)
        {
            return Ok(_user.GetUser(id));
        }

        [ActionName("GetAll")]
        public IHttpActionResult GetAll()
        {
            return Ok(_user.GetUsers());
        }

        // POST api/User/Logout
        [ActionName("Register")]
        public IHttpActionResult Register(DTO.User user)
        {
            try
            {
                _user.Register(user);
                return new MamalonResult(HttpStatusCode.OK,DTO.MamalonaMessage.Success);
            }
            catch (DTO.MamalonaException mamalon)
            {
                return new MamalonResult(HttpStatusCode.BadRequest, mamalon.Message);
            }
        }

        //POST api/User/Login
        [ActionName("Login")]
        public IHttpActionResult Login()
        {
            try
            {
                string email = ((string[])(Request.Headers.GetValues("email")))[0];
                string password = ((string[])(Request.Headers.GetValues("password")))[0];

                string token = _user.Login(email, password);
                return Ok(token);
            }
            catch (DTO.MamalonaException mamalon)
            {
                return new MamalonResult(HttpStatusCode.NotFound, mamalon.Message);
            }
        }

        // POST api/User/Logout
        [ActionName("Logout")]
        public IHttpActionResult Logout()
        {
            try
            {
                //TODO get token from request.                
                string token = Request.Headers.Authorization.Parameter;
                _user.Logout(token);
                return new MamalonResult(HttpStatusCode.OK,DTO.MamalonaMessage.Success);
            }
            catch (DTO.MamalonaException mamalon)
            {
                return new MamalonResult(HttpStatusCode.NonAuthoritativeInformation, mamalon.Message);
            }
        }
    }
}