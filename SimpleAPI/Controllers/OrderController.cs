using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleAPI.Models;
using SimpleAPI.ModelSettings;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        [HttpGet]
        public async Task<ActionResult> GetOrders()
        {
            var response = await Task.Run(() => Ok(Json(OrderSettings.orders)));
            return response;
        }

        [HttpGet("byClient")]
        public async Task<ActionResult> GetOrdersByClient(int clientId)
        {
            var client = ClientSettings.clients.FirstOrDefault(x => x.id == clientId);
            if (client == null)
                return await Task.Run(() => NotFound(new Response("this user not found")));
            var orders = OrderSettings.orders.Where(x => x.clientId == clientId);
            return await Task.Run(() => Ok(Json(orders)));
            
        }


    }
}

