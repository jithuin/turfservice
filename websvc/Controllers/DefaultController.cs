using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace websvc.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Authorize]
    public class DefaultController : ApiController

    {

        Products[] products = new Products[]
       {
            new Products { id = 1, category = "Sugar" ,packets =new Packing[]{ new Packing {id=1,description ="1x5kg"} , new Packing { id = 2, description = "5x5kg" } } },
            new Products { id = 2, category = "Salt" },
            new Products { id = 3, category = "Turf" },
            new Products { id = 4, category = "Choco" }
       };

        public Products[] Get()
        {
            

                   return products;

        }
        public Products Put(Packing packet)
        {
            Packing[] Packs = new Packing[] { packet };
            return new Products { id = 5, category = "mag" ,packets= Packs };
        }

        public IEnumerable<Products> GetDefault(int id)
        {

            return (from prod in products where prod.id == id select prod);

        }
    }

    public class Products
    {
        public int id { get; set; }
        public string category { get; set; }
        public Packing[] packets;
    }
    public class Packing
    {
        public int id { get; set; }
        public string description { get; set; }
    }
    
}
