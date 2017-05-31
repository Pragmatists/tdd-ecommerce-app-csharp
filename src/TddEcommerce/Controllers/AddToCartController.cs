using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace TddEcommerce.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    public class AddToCartController : Controller
    {
       
        [HttpPost("user/{userId}/cart/items")]
        public void Post(int userId, [FromBody]string value)
        {
        }
        
    }
}
