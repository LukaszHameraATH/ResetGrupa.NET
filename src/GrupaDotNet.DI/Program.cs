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

// plan na następne spotkania
// inne biblioteki do DI - szybko, AutoFAC, Ninja, Unity (?),
// ASP.NET - rozdzielenie warstw z DI,

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