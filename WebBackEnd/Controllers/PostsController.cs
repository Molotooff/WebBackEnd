using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using WebBackEnd.Domains.Posts.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Server.IIS.Core;
using WebBackEnd.Domains.Posts;
using Microsoft.AspNetCore.Routing;

namespace WebBackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsController : ControllerBase
    {

        private readonly PostsService _service;
        public PostsController(PostsService service)
        {
            _service = service;
        }

        /// <summary>
        /// Получение всех публикаций
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Get")]
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
        [Route("CreatePost")]
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
        [Route("UpdatePost")]
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
        [Route("DeletePost")]
        public async Task<bool> DeletePost(Guid id)
        {
            return await _service.DeletePost(id);
        }
    }
}
