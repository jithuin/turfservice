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
                new TurfBooking {Id =2,TurfMaster=new TurfMaster{Id=2, Name="FootOut", TypeofTurf=0, Location="Petta"} },
                new TurfBooking {Id =3,TurfMaster=new TurfMaster{Id=3, Name="Game5", TypeofTurf=0, Location="Chungham"} },
                new TurfBooking{Id =4,TurfMaster=new TurfMaster{Id=4, Name="fifa", TypeofTurf=0, Location="ramanattukara"} }
            };

            public TurfBooking[] Get()
            {
                return turfBooking;
            }
               
    }
}
