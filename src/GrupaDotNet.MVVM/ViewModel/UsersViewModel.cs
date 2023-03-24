using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using GrupaDotNet.Shared;

namespace GrupaDotNet.MVVM.ViewModel
{
    internal class UsersViewModel
    {
        private readonly IUserRepository _userRepository;

        public UsersViewModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            Users = ConvertToViewModels(userRepository.GetAll());
            AddRandomUserCommand = new DelegateCommand(AddRandomUser);
            BlockRandomUserCommand = new DelegateCommand(BlockRandomUser);
        }

        public ObservableCollection<UserViewModel> Users { get; }

        public ICommand AddRandomUserCommand { get; }
        public ICommand BlockRandomUserCommand { get; }

        private void AddRandomUser()
        {
            var user = new User(Guid.NewGuid(), "Marek", "Nowak", true);
            _userRepository.Save(user);
            Users.Add(new UserViewModel(user));
        }

        private void BlockRandomUser()
        {
            var userToBlockIndex = Users.Count - 1;
            if (userToBlockIndex < 0)
                return;

            var userToBlock = Users[userToBlockIndex];

            //var user = userToBlock.ToModel();
            var user = _userRepository.GetById(userToBlock.Id);
            if (user is null)
            {
                MessageBox.Show("Nie ma takiego usera!");
                return;
            }

            user.Deactivate();
            _userRepository.Save(user);

            Users[userToBlockIndex] = new UserViewModel(user);
        }

        private ObservableCollection<UserViewModel> ConvertToViewModels(IEnumerable<User> users)
        {
            var userViewModels = users.Select(x => new UserViewModel(x));
            return new ObservableCollection<UserViewModel>(userViewModels);
        }
    }
}
