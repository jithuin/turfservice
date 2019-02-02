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
                new TurfBooking { Id =1,TurfMaster =new TurfMaster{Id=1,Description="Bridge", Location="Feroke"} },
                new TurfBooking {Id =2,Time="10:00", RegistrationDate="12-1-2019", Amount=1000, ApprovedStatus="Waiting"},
                new TurfBooking {Id =3}
            };

            public TurfBooking[] Get()
            {
                return turfBooking;
            }
               
    }
}
