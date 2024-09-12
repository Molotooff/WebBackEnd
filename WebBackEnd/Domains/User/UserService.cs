using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBackEnd.DAL;
using UserModel = WebBackEnd.Domains.User.Models.User;



namespace WebBackEnd.Domains.User
{
    public class UserService
    {
        private WebBackEndContext _context;

        public UserService(WebBackEndContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получение всех пользователей
        /// </summary>
        /// <returns></returns>
        public async Task<List<UserModel>> GetAllUsers()
        {
            return await _context.User.ToListAsync();
        }

        /// <summary>
        /// Создание пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Guid> CreateUser(Models.User user)
        {
            var existingUser = await _context.User
                .Where(x => x.Id == user.Id)
                .FirstOrDefaultAsync();

            if (existingUser != null)
            {
                throw new Exception($"Данная публикая уже существует");
            }

            UserModel newUser = new()
            {
                Id = Guid.NewGuid(),
                Email = user.Email,
                Password = user.Password
            };

            _context.User.Add(newUser);

            _context.SaveChanges();

            return newUser.Id;
        }

        /// <summary>
        /// Обновление пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<UserModel> UpdateUser(UserModel user)
        {
            var oldUser = await _context.User
                .Where(x => x.Id == user.Id)
                .FirstOrDefaultAsync();

            if (oldUser == null)
            {
                throw new Exception($"Такой публикаци не существует");
            }

            oldUser.Email = user.Email;
            oldUser.Password = user.Password;

            await _context.SaveChangesAsync();

            return oldUser;
        }

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> DeleteUser(Guid userId)
        {
            var existingUser = await _context.User
                    .Where(x => x.Id == userId)
                    .FirstOrDefaultAsync() ?? throw new Exception($"Данная публикации не существует");

            _context.User.Remove(existingUser);

            await _context.SaveChangesAsync();

            return true;

        }

    }
}
