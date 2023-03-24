using System;
using Autofac;
using DesktopApp.AutoFac.ViewModels;

namespace DesktopApp.AutoFac;

public class Bootstrapper: IDisposable
{
    private IContainer _container;

    public void Run()
    {
        _container ??= BuildContainer();
        var mainWindow = _container.Resolve<MainWindow>(); // w MS GetService<>, GetRequiredService<>
        mainWindow.Show();
    }

    private IContainer BuildContainer()
    {
        var builder = new ContainerBuilder(); // new ServiceCollection() - w MS
        RegisterTypes(builder);
        return  builder.Build(); // IServiceProvicer - w MS
    }

    private void RegisterTypes(ContainerBuilder builder)
    {
        builder.RegisterType<MainWindow>();
        builder.RegisterType<MainViewModel>();
    }

    public void Dispose()
    {
        _container?.Dispose();
    }
}