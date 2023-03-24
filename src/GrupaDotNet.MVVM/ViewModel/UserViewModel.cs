using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using GrupaDotNet.Shared;

namespace GrupaDotNet.MVVM.ViewModel
{
    internal class UserViewModel: ViewModelBase
    {
        private readonly Brush _activeColor = Brushes.Green;
        private readonly Brush _blockedColor = Brushes.Red;

        public UserViewModel(User user)
        {
            Id = user.Id;
            FullName = $"{user.FirstName} {user.LastName}";
            IsActive = user.IsActive ? _activeColor : _blockedColor;
        }

        public Guid Id { get; }
        public string FullName { get; }

        //private Brush _isActive;
        //public Brush IsActive
        //{
        //    get => _isActive;
        //    private set => SetProperty(ref _isActive, value);
        //}

        public Brush IsActive { get; }

        //public void Block()
        //{
        //    IsActive = _blockedColor;
        //}

        //public User ToModel()
        //{
        //    return new User(Id, )
        //}
    }
}
