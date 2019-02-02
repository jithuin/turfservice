using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using websvc.Models;

namespace websvc.Controllers
{
    public class TurfBookingController : ApiController
    {
           TurfBooking[] turfBooking = new TurfBooking[]
            {
                new TurfBooking { Id =1},
                new TurfBooking {Id =2},
                new TurfBooking {Id =3},
                new TurfBooking {Id =4}                
            };

            public TurfBooking[] Get()
            {
                return turfBooking;
            }
               
    }
}
