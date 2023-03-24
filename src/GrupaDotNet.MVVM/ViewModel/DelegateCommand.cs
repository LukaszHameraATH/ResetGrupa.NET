using System;
using System.Windows.Input;

namespace GrupaDotNet.MVVM.ViewModel
{

    internal class DelegateCommand : ICommand
    {
        private readonly Action _action;

        public DelegateCommand(Action action)
        {
            _action = action;
        }

        public bool CanExecute(object? parameter)
            => true;

        public void Execute(object? parameter)
            => _action?.Invoke();

        public event EventHandler? CanExecuteChanged;
    }
}
