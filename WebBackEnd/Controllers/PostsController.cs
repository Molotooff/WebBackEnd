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

    }
}
