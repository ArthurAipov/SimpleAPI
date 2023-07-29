using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleAPI.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : Controller
    {
        [HttpPost]
        public async Task<ActionResult> CreateClient(Client client)
        {
            if (Settings.clients.Count == 0)
                client.id = 1;
            else
                client.id = Settings.clients.Last().id;
            if (!Settings.CreateClient(client))
                return await Task.Run(() => BadRequest(Json(new Response("Unknown error"))));
            else
                return await Task.Run(() => Ok(Json(new Response("New client created"))));
        }

        [HttpGet]
        public async Task<ActionResult> GetClients()
        {
            var clients = Settings.clients;
            var response = await Task.Run(() => Ok(Json(clients)));
            return response;
        }

    }
}

