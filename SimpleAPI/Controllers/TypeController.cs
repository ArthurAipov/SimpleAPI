﻿using System;
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
    public class TypeController : Controller
    {
        // получение всех типов
        [HttpGet]
        public async Task<ActionResult> GetTypes()
        {
            return await Task.Run(() => Ok(Json(Settings.types)));
        }

        [HttpPost]
        public async Task<ActionResult> CreateType(Models.Type type)
        {
            if (Settings.types.Count == 0)
                type.id = 1;
            else
                type.id = Settings.types.Last().id + 1;
            Settings.CreateType(type);
            return await Task.Run(() => Ok(Json(Settings.types)));
        }

    }
}

