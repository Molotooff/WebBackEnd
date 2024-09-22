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
        /// Создание списка пользователей
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateUsers")]
        public async Task<List<Guid>> CreateUsers(List<User> users)
        {
            return await _service.CreateUsers(users);
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

        /// <summary>
        /// Получение ифнормации о пользователе из VK
        /// </summary>
        /// <param name="VKid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetVkUser")]
        public async Task<User> GetVkUser(long VKid) 
        {
            return await _service.GetVKUser(VKid);
        }

        /// <summary>
        /// Получение информации о друзьях пользователя из VK
        /// </summary>
        /// <param name="VKid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetFriends")]
        public async Task<List<User>> GetFriends(long VKid) 
        {
            return await _service.GetFriends(VKid);
        }

        /// <summary>
        /// Получение информации о пользователях в сообществе VK
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetUsersFromCommunity")]
        public async Task<List<User>> GetUsersFromCommunity(string groupId)
        {
            return await _service.GetUsersFromCommunity(groupId);
        }

        /// <summary>
        /// Сохранение друзей из ВК в БД
        /// </summary>
        /// <param name="VKid"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SaveUserFriends")]
        public async Task<List<Guid>> SaveUserFriends(long VKid)
        {
            var friends = await _service.GetFriends(VKid);
            return await _service.CreateUsers(friends);
        }
    }
}
