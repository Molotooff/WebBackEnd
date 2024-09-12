using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBackEnd.DAL;
using WebBackEnd.Domains.Posts.Models;

namespace WebBackEnd.Domains.Posts
{
    public class PostsService
    {
        private readonly WebBackEndContext _context;

        public PostsService(WebBackEndContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получение всех публикаций
        /// </summary>
        /// <returns></returns>
        public List<Post> GetAllPosts()
        {
            return _context.Posts.ToList();
        }

        /// <summary>
        /// Занесение публикации в БД
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Guid> CreatePost(Post post)
        {
            var existingPost = await _context.Posts
                .Where(x => x.Id == post.Id)
                .FirstOrDefaultAsync();

            if (existingPost != null)
            {
                throw new Exception($"Данная публикая уже существует");
            }

            var newPost = new Post()
            {
                Id = Guid.NewGuid(),
                Link = post.Link,
                Content = post.Content
            };

            _context.Posts.Add(newPost);

            await _context.SaveChangesAsync();

            return newPost.Id;
        }

        /// <summary>
        /// Обновление публикации
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Post> UpdatePost(Post post)
        {
            var oldPost = await _context.Posts
                .Where(x => x.Id == post.Id)
                .FirstOrDefaultAsync();

            if (oldPost == null)
            {
                throw new Exception($"Такой публикаци не существует");
            }

            oldPost.Link = post.Link;
            oldPost.Content = post.Content;

            await _context.SaveChangesAsync();

            return oldPost;
        }

        /// <summary>
        /// Удаление публикации
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> DeletePost(Guid postId)
        {
            var existingPost = await _context.Posts
                .Where(x => x.Id == postId)
                .FirstOrDefaultAsync() ?? throw new Exception($"Данная публикации не существует");

            _context.Posts.Remove(existingPost);

            await _context.SaveChangesAsync();

            return true;

        }
    }
}
