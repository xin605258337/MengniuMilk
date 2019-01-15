﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MengniuMilk.Api.Controllers
{
    using MengniuMilk.Entity;
    using MengniuMilk.IService;
    using MengniuMilk.Service;
    using Unity.Attributes;
    public class ResultEenterServicesController : ApiController
    {
        [Dependency]

        public ResultEenterServices ResultEenterServices { get; set; }
        [HttpPost]
        [Route("AddResultEenters")]
        public int AddResultEenters(ResultEenter resultEenter)
        {
            return ResultEenterServices.AddResultEenters(resultEenter);

        }

        }
}
