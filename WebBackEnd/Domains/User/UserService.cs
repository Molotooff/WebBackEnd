using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBackEnd.DAL;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet;
using UserModel = WebBackEnd.Domains.User.Models.User;
using WebBackEnd.Domains.User.Models;



namespace WebBackEnd.Domains.User
{
    public class UserService
    {
        private readonly VkApi _api;
        private readonly WebBackEndContext _context;

        public UserService(WebBackEndContext context, VkApi api)
        {
            _context = context;
            _api = api;
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
                VKID = user.VKID,
                FirstName = user.FirstName,
                SecondName = user.SecondName,
                ScreenName = user.ScreenName,
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

            oldUser.VKID = user.VKID;
            oldUser.FirstName = user.FirstName;
            oldUser.SecondName = user.SecondName;
            oldUser.ScreenName = user.ScreenName;

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

        /// <summary>
        /// Получение пользователя VK
        /// </summary>
        /// <param name="idVK"></param>
        /// <returns></returns>
        public async Task<UserModel> GetVKUser(long idVK) 
        {

            var userVK = _api.Users.Get(new long[] { idVK }).FirstOrDefault();

            UserModel newUser = new()
            {
                Id = Guid.NewGuid(),
                VKID = userVK.Id,
                FirstName = userVK.FirstName,
                SecondName = userVK.LastName,
                ScreenName = userVK.ScreenName
            };

            return newUser;
        }

        /// <summary>
        /// Получение друзей пользователя
        /// </summary>
        /// <param name="idVK"></param>
        /// <returns></returns>
        public async Task<List<UserModel>> GetFriends(long idVK) 
        {
            var VKfriends = _api.Friends.Get(new FriendsGetParams
            {
                UserId = idVK,
                Fields = ProfileFields.FirstName | ProfileFields.LastName | ProfileFields.ScreenName
            });

            List<UserModel> friends = new();

            foreach (var friend in VKfriends) 
            {
                UserModel newUser = new()
                {
                    Id = Guid.NewGuid(),
                    VKID = friend.Id,
                    FirstName = friend.FirstName,
                    SecondName = friend.LastName,
                    ScreenName = friend.ScreenName
                };
                friends.Add(newUser);
            }

            return friends;
        }

        public async Task<List<UserModel>> GetUsersFromCommunity(string groupId) 
        {
            var usersFromCommunity = _api.Groups.GetMembers(new GroupsGetMembersParams
            {
                GroupId = groupId,
                Fields = UsersFields.All
            });

            List<UserModel> users = new();

            foreach (var user in usersFromCommunity)
            {
                UserModel newUser = new()
                {
                    Id = Guid.NewGuid(),
                    VKID = user.Id,
                    FirstName = user.FirstName,
                    SecondName = user.LastName,
                    ScreenName = user.ScreenName
                };
                users.Add(newUser);
            }

            return users;
        }
    }
}
