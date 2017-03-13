using SmartMe.Model;
using SmartMe.Service;
using SmartMe.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartMe.Controllers
{
    [RoutePrefix("api/passwords")]
    public class PasswordSafeController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IList<PasswordSafe> Get(
            [FromUri] string serviceName = null, 
            [FromUri] string username = null)
        {
            try
            {
                return new PasswordSafeService().GetRecords();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("save")]
        public PasswordSafeResponse SaveRecord(PasswordSafeRequest request)
        {
            try
            {
                PasswordSafeService service = new PasswordSafeService();
                service.SaveRecord();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return null;
        }
    }
}
