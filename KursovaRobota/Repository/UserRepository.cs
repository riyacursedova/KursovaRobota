using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using KursovaRobota;

namespace KursovaRobota
{
    public class UserRepository : IUserRepository
    {
        private List<User> _users = new List<User>();
        private const string UsersFilePath = "users.json";

        public UserRepository()
        {
            LoadUsers();
        }

        public User GetUserByUsername(string username)
        {
            return _users.FirstOrDefault(u => u.Username == username);
        }

        public void AddUser(User user)
        {
            int newId = _users.Any() ? _users.Max(u => u.Id) + 1 : 1;
            user.Id = newId;
            _users.Add(user);
            SaveUsers();
        }
        
        public void UpdateUser(User user)
        {
            SaveUsers();
        }

        private void SaveUsers()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(_users, options);
            File.WriteAllText(UsersFilePath, json);
        }

        private void LoadUsers()
        {
            if (!File.Exists(UsersFilePath)) return;
            try
            {
                string json = File.ReadAllText(UsersFilePath);
                _users = JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
            }
            catch
            {
                _users = new List<User>();
            }
        }
    }
}