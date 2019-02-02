using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TurfManagement;

namespace websvc.Controllers
{
    public class TurfBookingController : ApiController
    {
           TurfBooking[] turfBooking = new TurfBooking[]
            {
                new TurfBooking { Id =1,TurfMaster =new TurfMaster{Id=1,Description="Bridge"} },
                new TurfBooking {Id =2},
                new TurfBooking {Id =3}
            };

            public TurfBooking[] Get()
            {
                return turfBooking;
            }
               
    }
}
