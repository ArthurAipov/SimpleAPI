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
    public class ClientController : Controller
    {
        [HttpPost]
        public async Task<ActionResult> CreateClient(Client client, int userId)
        { 
            var user = UserSettings.users.FirstOrDefault(x => x.id == userId);
            if (user == null)
            {
                return await Task.Run(() => BadRequest(Json(new Response("Not foud"))));
            }
            else
            {
                client.user = user;
                client.userId = user.id;
            }

            if (ClientSettings.clients.Count == 0)
                client.id = 1;
            else
                client.id = ClientSettings.clients.Last().id;

            if (!ClientSettings.CreateClient(client))
                return await Task.Run(() => BadRequest(Json(new Response("Unknown error"))));
            else
                return await Task.Run(() => Ok(Json(new Response("New client created"))));
        }

        [HttpGet]
        public async Task<ActionResult> GetClients()
        {
            var response = await Task.Run(() => Ok(Json(ClientSettings.clients)));
            return response;
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteClient(int clientId)
        {
            var client = ClientSettings.clients.FirstOrDefault(x => x.id == clientId);
            if (client == null)
                return await Task.Run(() => NotFound(Json(new Response("this user not found"))));
            ClientSettings.DeleteClient(client);
            return await Task.Run(() => Ok(Json(ClientSettings.clients)));
        }


        [HttpGet("{clientId}")]
        public async Task<ActionResult> GetClientBasket(int clientId)
        {
            var client = ClientSettings.clients.FirstOrDefault(x => x.id == clientId);
            if (client == null)
                return await Task.Run(() => NotFound(new Response("this user not found")));
            return await Task.Run(() => Ok(Json(client.basket)));
        }

        [HttpPost("product/{productId}")]
        public async Task<ActionResult> AddProduct(int clientId, int productId)
        {
            var product = ProductSettings.products.FirstOrDefault(x => x.id == productId);
            var client = ClientSettings.clients.FirstOrDefault(x => x.id == clientId);
            if (client == null)
                return await Task.Run(() => NotFound(new Response("this user not found")));
            if (product == null)
                return await Task.Run(() => NotFound(new Response("this product not found")));
            client.basket.Add(product);
            return await Task.Run(() => Ok(Json(client.basket)));
        }
        [HttpPost("client/{clientId}/order")]
        public async Task<ActionResult> CreateClientOrder(int clientId)
        {
            var client = ClientSettings.clients.FirstOrDefault(x => x.id == clientId);
            if (client == null)
                return await Task.Run(() => NotFound(new Response("this user not found")));
            if (client.basket.Count() == 0)
                return await Task.Run(() => Ok(Json(new Response("basket cannot be empty"))));
            OrderSettings.CreateOrder(client, client.basket);
            var clientOrders = OrderSettings.orders.Where(x => x.clientId == clientId);
            client.basket = new List<Product>();
            return await Task.Run(() => Ok(Json(clientOrders)));
        }

    }
}

