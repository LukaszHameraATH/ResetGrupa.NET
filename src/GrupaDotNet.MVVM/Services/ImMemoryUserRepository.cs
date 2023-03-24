using System;
using System.Collections.Generic;
using GrupaDotNet.Shared;

namespace GrupaDotNet.MVVM.Services
{
    internal class ImMemoryUserRepository: IUserRepository
    {
        private readonly Dictionary<Guid, User> _users;

        public ImMemoryUserRepository()
        {
            _users = GenerateData();
        }

        public IEnumerable<User> GetAll()
        {
            return _users.Values;
        }

        public User? GetById(Guid id)
        {
            return _users.TryGetValue(id, out var user)
                ? user
                : default;
        }

        public void Save(User user)
        {
            if (!_users.TryGetValue(user.Id, out var existsUser))
            {
                _users.Add(user.Id, user);
                return;
            }

            _users[user.Id] = user;
        }

        private Dictionary<Guid, User> GenerateData()
        {
            var user = new User(Guid.NewGuid(), "Jan", "Kowalski", false);
            return new Dictionary<Guid, User>
            {
                { user.Id, user }
            };
        }
    }
}
