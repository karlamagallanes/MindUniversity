using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using BL = MindEval.FiveSquare.Business;
using DTO = MindEval.FiveSquare.Common;

namespace MindEval.FiveSquare.App.Controllers
{
    [Authorize]
    public class PlaceController : ApiController
    {
        private BL.IPlace _place = new BL.Place();
        private BL.ICheckManager _checkManager = new BL.CheckManager();

        [ActionName("Checkin")]
        public IHttpActionResult CheckIn(int id)
        {
            try
            {
                string token = Request.Headers.Authorization.Parameter;
                _checkManager.CheckIn(id, token);
                return new MamalonResult(HttpStatusCode.OK, DTO.MamalonaMessage.Success);
            }
            catch (DTO.MamalonaException mamalon)
            {
                return new MamalonResult(HttpStatusCode.Forbidden, mamalon.Message);
            }
            catch
            {
                return new MamalonResult(HttpStatusCode.OK, DTO.MamalonaMessage.Error);

            }

        }

        [ActionName("Checkout")]
        public IHttpActionResult CheckOut(int id)
        {
            try
            {
                string token = Request.Headers.Authorization.Parameter;
                _checkManager.CheckOut(id, token);
                return new MamalonResult(HttpStatusCode.OK, DTO.MamalonaMessage.Success);
            }
            catch (DTO.MamalonaException mamalon)
            {
                return new MamalonResult(HttpStatusCode.Forbidden, mamalon.Message);
            }
            catch
            {
                return new MamalonResult(HttpStatusCode.OK, DTO.MamalonaMessage.Error);

            }
        }


        [ActionName("CheckCount")]
        public IHttpActionResult CheckCount(int id)
        {
            try
            {
                string token = Request.Headers.Authorization.Parameter;
                int count = _checkManager.Count(id, token);
                Ok(count);
                return new MamalonResult(HttpStatusCode.OK, DTO.MamalonaMessage.Success);
            }
            catch (DTO.MamalonaException mamalon)
            {
                return new MamalonResult(HttpStatusCode.Forbidden, mamalon.Message);
            }
            catch
            {
                return new MamalonResult(HttpStatusCode.BadRequest, DTO.MamalonaMessage.Error);
            }
        }

        [ActionName("Rate")]
        public IHttpActionResult Rate(int id)
        {
            try
            {
                string token = Request.Headers.Authorization.Parameter;
                decimal rate = _checkManager.Rate(id, token);
                Ok(rate);
                return new MamalonResult(HttpStatusCode.OK, DTO.MamalonaMessage.Success);
            }
            catch (DTO.MamalonaException mamalon)
            {
                return new MamalonResult(HttpStatusCode.Forbidden, mamalon.Message);
            }
            catch
            {
                return new MamalonResult(HttpStatusCode.BadRequest, DTO.MamalonaMessage.Error);
            }
        }

        [ActionName("Rate")]
        public IHttpActionResult Rate()
        {
            try
            {
                string token = Request.Headers.Authorization.Parameter;
                int id = int.Parse(((string[])(Request.Headers.GetValues("id")))[0]);
                int rate = int.Parse(((string[])(Request.Headers.GetValues("rate")))[0]);

                _checkManager.Rate(id, rate, token);
                return new MamalonResult(HttpStatusCode.OK, DTO.MamalonaMessage.Success);
            }
            catch (DTO.MamalonaException mamalon)
            {
                return new MamalonResult(HttpStatusCode.Forbidden, mamalon.Message);
            }
            catch
            {
                return new MamalonResult(HttpStatusCode.BadRequest, DTO.MamalonaMessage.Error);
            }
        }


        [ActionName("Nearby")]
        public IHttpActionResult NearbyPlaces()
        {
            try
            {
                string token = Request.Headers.Authorization.Parameter;
                decimal lat = decimal.Parse(((string[])(Request.Headers.GetValues("latitude")))[0]);
                decimal lon = decimal.Parse(((string[])(Request.Headers.GetValues("longitude")))[0]);
                List<DTO.Place> nearby = _place.GetNearby(lat, lon, token);
                return Ok(nearby);
            }
            catch (DTO.MamalonaException mamalon)
            {
                return new MamalonResult(HttpStatusCode.Forbidden, mamalon.Message);
            }
            catch
            {
                return new MamalonResult(HttpStatusCode.BadRequest, DTO.MamalonaMessage.Error);
            }
        }
    }
}