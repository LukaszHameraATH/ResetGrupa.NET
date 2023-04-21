using GrupaDotNet.Spotkanie6.Models;

namespace GrupaDotNet.Spotkanie6.Infrastructure.Database
{
    public interface IAuthorRepository
    {
        Author? GetById(Guid id);
        IEnumerable<Author> GetAll();
    }

    public class AuthorRepository: IAuthorRepository
    {
        private readonly Dictionary<Guid, Author> _authors
            = new Dictionary<Guid, Author>();

        public AuthorRepository()
        {
            var id = Guid.NewGuid();
            _authors.Add(id, new Author(id, "Jan", "Kowalski"));
        }

        public Author? GetById(Guid id)
        {
            return _authors.TryGetValue(id, out var author) ? author : null;
        }

        public IEnumerable<Author> GetAll()
        {
            return _authors.Values;
        }
    }
}
