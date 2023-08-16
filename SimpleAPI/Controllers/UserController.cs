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
    public class UserController : Controller
    {
        // получение всех пользователей 
        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            // получение списка всех пользователей
            var response = await Task.Run(() => Ok(Json(UserSettings.users)));
            return response;
        }

        // реализация удаления пользователей
        [HttpDelete]
        public async Task<ActionResult> DeleteUser(int id)
        {
            //поиск пользователя по id
            var user = UserSettings.users.FirstOrDefault(x => x.id == id);
            // проверка существует ли пользователь с таким id
            if (user == null)
            {
                // вывод сообщения о том что такого пользователя нет
                var response = await Task.Run(() => NotFound(Json(new Response("This user is not found"))));
                return response;
            }
            else
            {
                // Удаление пользователя
                UserSettings.DeleteUser(user);
                // вывод списка после удаления пользователя
                var response = await Task.Run(() => Ok(Json(UserSettings.users)));
                return response;
            }
        }

        // создание нового пользователя
        [HttpPost]
        public async Task<ActionResult> CreateUser(User user, int typrId)
        {
            // проверка на наличие пользователей
            if (UserSettings.users.Count == 0)
                // установка пользователю уникальный id
                user.id = 1;
            else
                // установка пользователю уникальный id
                user.id = UserSettings.users.Last().id + 1;
            // проверка выбранного типа
            var type = TypeSettings.types.FirstOrDefault(x => x.id == typrId);
            // если тип не найден
            if (type == null)
                // сообщение о том что данного типа нет
                return await Task.Run(() => NotFound(Json(new Response("This type is not found"))));
            // задание типа пользователю
            user.type = type;
            user.typeId = typrId;
            // создание пользователя
            UserSettings.CreateUser(user);
            // вывод списка всех пользователей
            var response = await Task.Run(() => Ok(Json(UserSettings.users)));
            return response;

        }

        // поиск пользователя по id
        [HttpGet("{id}")]
        public async Task<ActionResult> GetUserById(int id)
        {
            //поиск пользователя по id
            var user = UserSettings.users.FirstOrDefault(x => x.id == id);
            // проверка существует ли пользователь с таким id
            if (user == null)
            {
                // вывод сообщения о том что такого пользователя нет
                var response = await Task.Run(() => NotFound(Json(new Response("This user is not found"))));
                return response;
            }
            else
            {
                // вывод данных пользователя 
                var response = await Task.Run(() => NotFound(Json(user)));
                return response;
            }
        }

        // редактирование пользователя по id
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, User newUser)
        {
            // поиск пользователя
            var user = UserSettings.users.FirstOrDefault(x => x.id == id);
            // проверка существует ли пользователь с таким id
            if (user == null)
                // вывод сообщения о том что такого пользователя нет
                return await Task.Run(() => NotFound(Json(new Response("This user is not found"))));
            // применение новых параметров для старого пользователя
            user.login = newUser.login;
            user.password = newUser.password;
            // вывод новых данных о пользователе 
            return await Task.Run(() => Ok(Json(user)));
        }
    }
}

