using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using WebBackEnd.Domains.User;
using WebBackEnd.Domains.User.Models;

namespace WebBackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;
        public UserController(UserService service)
        {
            _service = service;
        }

        /// <summary>
        /// Получение всех пользователей
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllUser")]
        public async Task<List<User>> GetAllUser()
        {
            return await _service.GetAllUsers();
        }

        /// <summary>
        /// Создание пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateUser")]
        public async Task<Guid> CreateUser(User user)
        {
            return await _service.CreateUser(user);
        }

        /// <summary>
        /// Обновление данных пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateUser")]
        public async Task<User> UpdateUser(User user)
        {
            return await _service.UpdateUser(user);
        }

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<bool> DeleteUser(Guid id)
        {
            return await _service.DeleteUser(id);
        }
    }
}
