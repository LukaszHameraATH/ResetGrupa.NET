// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Hello, World!");

// var smsSenderEra = new SMSSenderEra();
// var snsSenderTMobile = new SMSSenderTMobile("test");
// var notifier = new Notifier(smsSenderEra, new MailSender("234"));
// var notifier2 = new Notifier(snsSenderTMobile, new MailSender("234"));


// 5. DI
var services = new ServiceCollection();

services.AddSingleton<Notifier>();
services.AddTransient<ISMSSender, SMSSenderTMobile>();
services.AddTransient<IMailSender>(x=>new MailSender("Config"));

services.AddScoped<ScopedService>();

services.AddTransient<ILogger, FileLogger>(x => new FileLogger("logi.txt"));
services.AddTransient<ILogger, ConsoleLogger>();
services.AddTransient<MainLogger>();

services.Decorate<ISMSSender, SmsSenderLoggingDecorator>();

using var provider = services.BuildServiceProvider();

var notifier = provider.GetRequiredService<Notifier>();
var notifier2 = provider.GetRequiredService<Notifier>();

var notifier3 = provider.GetService<Notifier>();

using var scope = provider.CreateScope();
var scopeProvider = scope.ServiceProvider;
var scoped = scopeProvider.GetService<ScopedService>();
var scoped2 = scopeProvider.GetService<ScopedService>();

using var scope2  = provider.CreateScope();
var scopeProvider2 = scope2.ServiceProvider; 
var scoped3 = scopeProvider2.GetService<ScopedService>();
var scoped4 = scopeProvider2.GetService<ScopedService>();

var logger = provider.GetRequiredService<MainLogger>();
logger.Log("Cześć z Grupy .NET!");

var logger2 = provider.GetService<ILogger>(); // ConsoleLogger - ostatni zarejestrowany pod ILogger
// może być błąd
// może wyciągnąć FileLogger
// może wyciagnąć ConsoleLogger
// może zwrócić null

// plan na następne spotkania
// inne biblioteki do DI - szybko, AutoFAC, Ninja, Unity (?),
// ASP.NET - rozdzielenie warstw z DI,

var smsSender = provider.GetRequiredService<ISMSSender>();
smsSender.Send("35", "test");

Console.ReadKey();

class ScopedService
{
    public ScopedService()
    {
        
    }
}

class User
{
    public User(string firstName, string lastName, string email, string phone)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
    }
    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
    public string Phone { get; }
}

// IoC + abstrakcje
class Notifier
{
    private readonly ISMSSender _smsSender;
    private readonly IMailSender _mailSender;

    public Notifier(ISMSSender smsSender, IMailSender mailSender)
    {
        _smsSender = smsSender;
        _mailSender = mailSender;
    }
    
    public void Notify(User user, string message)
    {
        // send SMS
        _smsSender.Send(user.Phone, message);
        // send Mail
        _mailSender.Send(user.Email, message);
        // send notification app
        //
    }
}

// 4. Przykładowe implementacje - nie są potrzebne, znajdują się w innym/ innych projektach - D z solida
internal class MailSender: IMailSender
{
    // konfiguracja serwera mailowego - ip, port itp
    public MailSender(string data)
    {
        
    }
    
    public void Send(string email, string message)
    {
        // łączyć
        // wysyłać
        // rozłączenie
    }
}

internal class SMSSenderTMobile: ISMSSender
{   
    
    // konfiguracja bramki smsowej
    public SMSSenderTMobile()
    {
        
    }
    
    public void Send(string phone, string message)
    {
        // Send sms
        // podłączniee do skrzynki
        // wysyłka smsa
        // .. 
    }

    private void Connect()
    {
        //...
    }
}

internal class SMSSenderEra: ISMSSender
{   
    public void Send(string phone, string message)
    {
    }
}

// 3. Stworzenie abstrakcji
public interface ISMSSender
{
    void Send(string phone, string message);
}

public interface IMailSender
{
    public void Send(string email, string message);
}

interface ILogger
{
    void Log(string message);
}

class FileLogger: ILogger
{
    private readonly string _filePath;

    public FileLogger(string filePath)
    {
        _filePath = filePath;
    }
    
    public void Log(string message)
    {
        File.AppendAllText(_filePath, message);
    }
}

class ConsoleLogger: ILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}

class MainLogger : ILogger
{
    private readonly IEnumerable<ILogger> _loggers;

    public MainLogger(IEnumerable<ILogger> loggers)
    {
        _loggers = loggers;
    }
    
    public void Log(string message)
    { 
        foreach (var logger in _loggers)
        {
            logger.Log("Cześć z Grupa .NET!");
        }
    }
}

class SmsSenderLoggingDecorator: ISMSSender
{
    private readonly ISMSSender _sender;

    public SmsSenderLoggingDecorator(ISMSSender sender)
    {
        _sender = sender;
    }
    
    public void Send(string phone, string message)
    {
        Console.WriteLine("Rozpoczynam wysyłkę smsa");
        _sender.Send(phone, message);
        Console.WriteLine("Wysłałem smsa");
    }
}

// 2. IoC
// class Notifier
// {
//     private readonly SMSSender _smsSender;
//     private readonly MailSender _mailSender;
//
//     public Notifier(SMSSender smsSender, MailSender mailSender)
//     {
//         _smsSender = smsSender;
//         _mailSender = mailSender;
//     }
//     
//     public void Notify(User user, string message)
//     {
//         // send SMS
//         _smsSender.Send(user.Phone, message);
//         // send Mail
//         _mailSender.Send(user.Email, message);
//         // send notification app
//         //
//     }
// }

// 1. Początek
// class Notifier
// {
//     tworzenie tutaj
//     private readonly SMSSender _smsSender = new SMSSender(...);
//     private readonly MailSender _mailSender = new SMSSender(...);
//
//     public Notifier(ISMSSender smsSender, IMailSender mailSender)
//     {
//         lub tworzenie w ctorze
//         _smsSender = new SMSSender(...);
//         _mailSender = new SMSSender(...);
//     }
//     
//     public void Notify(User user, string message)
//     {
//         // send SMS
//         _smsSender.Send(user.Phone, message);
//         // send Mail
//         _mailSender.Send(user.Email, message);
//         // send notification app
//         //
//     }
// }