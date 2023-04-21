using GrupaDotNet.Spotkanie6.DTOs;
using GrupaDotNet.Spotkanie6.Infrastructure.Database;
using GrupaDotNet.Spotkanie6.Models;
using Microsoft.AspNetCore.Mvc;

namespace GrupaDotNet.Spotkanie6.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet]
        public IEnumerable<AuthorDTO> Get()
        {
            var authors = _authorRepository.GetAll();
            return authors.ToDTOs();
        }
    }

    static class AuthorDTOExtensions
    {
        public static IEnumerable<AuthorDTO> ToDTOs(this IEnumerable<Author> authors)
        {
            return authors.Select(x => new AuthorDTO(x.Id, $"{x.FirstName} {x.LastName}"));
        }

    }
}
