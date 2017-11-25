using SmartMe.Model;
using SmartMe.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartMe.Controllers
{
    [RoutePrefix("api/accounts")]
    public class AccountController : ApiController
    {
        private LoggerService Log = LoggerService.GetInstance();

        [HttpGet]
        [Route("")]
        public IList<Account> Get()
        {
            try
            {
                return new AccountService().GetRecords();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw ex;
            }
        }

    }
}
