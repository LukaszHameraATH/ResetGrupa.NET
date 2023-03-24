// czytelność

int abc = 1;
int stringTEst = 1;

// Strategia, ...er
var configurationReader = new ConfigurationReader();
configurationReader.Read();

//var valueList = new List<int>(); - nie robić, zmienna ...List, Array itp.
var values = new List<int>();


// coś robią - liczenie, wysyłanie, notyfikowanie, odczytywanie, itd. itd
class EmailSender
{
    public void Send()
    {
        
    }
}

class Configuration
{
    
}

class ConfigurationReader
{
    public Configuration Read()
    {
        
    }
}

//
//interface I..Er

// interface IRepository - zarządznie listą/ kolekcją osób

class Person
{
    public Person(Guid id, string fullName)
    {
        Id = id;
        FullName = fullName;
    }
    public Guid Id { get; }
    public string FullName { get; }  
}

interface IPersonRepository // możemy zrobić implementacje dla listy w pamięci, dla DB, dla zapisu do pliku itd.
{
    Person? GetById(Guid id);
}

class PersonRepository: IPersonRepository
{
    private readonly Dictionary<Guid, Person> _people = new Dictionary<Guid, Person>();

    public Person? GetById(Guid id)
    {
        return _people.TryGetValue(id, out var person)
            ? person
            : null;
    }
}

// nie robić

class PersonManager // końcówka er, ale zbyt ogólne 
{
    // sprawdzania,
    // walidacja
    // dodawanie,
    // usuwanie
    // ..
}

// W programach musimy jakoś ponazywac klasy, zmienne itp. 
// Najlepiej jakby te nazwy odpowiadały realnym rzeczom
// Dla całej organizacji najlepiej zrobić słownik pojęć - aktualizować, utrzymywać ...

// Uwaga!
// Jedne pojęcia w progrmach mogą mieć inną role w róznych częściach programu
// W takim allegro - rzecz, którą sprzedajemy może miec różną nazwę w różnych kontekstach
// Sprzedawca to jest ogłoszenie - Dane, tytuł, cena, liczba sztuk itp.
// Kupujący - ogłoszenie, płatność (rzecz, która opłacamy)
// Kuriera - przesyłka - waga, rozmiar, skrtka,
// Magazyniera - pozycja w magazynie,
// Wszytko będzie miało jeden identyfikator

// DRY - Don't Repeat Yourself 
// Nie powtarzaj się, ale w logice 
// np. przy przelewie nie możesz wysłać więcej kasy niż masz na koncie - w 1 miejscu if,
// i nie możemy wykonac przelewu bez tego sprawdzenia

// Reguła KISS (ang. Keep it simple stupid, pol. zrób to prosto idioto) - pisać kod prosty, żeby był zrozumiały dla wszystkich. 
// W miare możliwośći lepiej użyć if zamiast rozbudowanej abstacji (klasy abstracyjnej i wielu implementacji)

// SOLID

// LoD
//W pełnej formie mówi ono, iż metoda danego obiektu może odwoływać się jedynie do metod należących do:
// tego samego obiektu,
// dowolnego parametru przekazanego do niej,
// dowolnego obiektu przez nią stworzonego,
// dowolnego składnika klasy, do której należy dana metoda[2].

class LoDA
{
    public string Name { get; }
    public Person Person { get; } = new Person(Guid.NewGuid(), "Jan Kowalski");

    public string FullName()
    {
        return Person.FullName + Name;
    }
}

class LoDB
{
    private readonly LoDA _privateLoda = new LoDA();
    
    public void Method(LoDA parameter)
    {
        // tego samego obiektu,
        MethodB();
        
        // dowolnego parametru przekazanego do niej,
        var name = parameter.Name;
        
        // dowolnego obiektu przez nią stworzonego,
        var loda = new LoDA();
        name = loda.Name;
        
        // dowolnego składnika klasy, do której należy dana metoda[2].
        name = _privateLoda.Name;

        // var personName = parameter.Person.FullName; // nie można tak robić
        // . . . . .
    }

    private void MethodB()
    {
        
    }
}

class ShoppingBasket
{
    // private produkty
    // lepiej zrobić metdę od PriceSum() niż publiczną liste produktów
    // ukrywanie pól - Hermetyzacja (informatyka)
}

// Separacja widoków od logiki - MVVM, MVP, MVC, FLUX, BLoC itd. itd
// Omówić na przykładach
// MVVM - WPF,
// MVP -WinForms [nie pokazywać, zapomnieć],
// MVC - ASP.NET/ Angular,
// Flux - React/ Blazor (Redux) - osobne spotkanie,
// BLoC - Flutter* osobne spotkanie

// Kohezja, Konesencja, Coupling (sprzężenie)
// Omówić

// SOLID, GRASP, CUPID, IDEALS (przu microserwisach*)
// Omowić

// Paradygmaty programowania 
// funkcyjne - pure function, immutable object,
// apsektowe - uruchamianie kodu przed/ po