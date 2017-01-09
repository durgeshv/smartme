﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartMe.Controllers
{
    [RoutePrefix("login")]
    public class LoginController : ApiController
    {
        [HttpGet]
        [Route("")]
        public string Get()
        {
            return "Hello World !!";
        }
    }
}
