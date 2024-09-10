using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using WebBackEnd.Domains.Posts;
using WebBackEnd.Domains.Posts.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace WebBackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsController : ControllerBase
    {

        private PostsService _service;
        public PostsController(PostsService service)
        {
            _service = service;
        }

        /// <summary>
        /// Получение всех публикаций
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Post> Get()
        {
            return _service.GetAllPosts();
        }

        /// <summary>
        /// Занесение публикации в ДБ
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPost]
        public async Task<Guid> CreatePost(Post post)
        {
            return await _service.CreatePost(post);
        }

        /// <summary>
        /// Обновление публикации
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<Post> UpdatePost(Post post)
        {
            return await _service.UpdatePost(post);
        }

        /// <summary>
        /// Удаление публикации
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<bool> DeletePost(Guid id)
        {
            return await _service.DeletePost(id);
        }

        [HttpGet]
        [Route("GetAllUser")]
        public async Task<List<User>> GetAllUser()
        {
            return await _service.GetAllUsers();
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<Guid> CreateUser(User user)
        {
            return await _service.CreateUser(user);
        }

        [HttpPut]
        [Route("UpdateUser")]
        public async Task<User> UpdateUser(User user)
        {
            return await _service.UpdateUser(user);
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<bool> DeleteUser(Guid id)
        {
            return await _service.DeleteUser(id);
        }

    }
}
