using System;
using System.Windows;
using System.Windows.Input;

namespace DesktopApp.AutoFac.ViewModels;

class DelegateCommand: ICommand
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

public class MainViewModel
{
    public MainViewModel()
    {
        OkCommand = new DelegateCommand(Ok);
    }
    
    public string Text { get; set; }
    public ICommand OkCommand { get;  }

    private void Ok()
    {
        MessageBox.Show($"Cześć {Text}");
    }
}