using GrupaDotNet.Spotkanie6.DTOs;
using GrupaDotNet.Spotkanie6.Infrastructure.Database;
using GrupaDotNet.Spotkanie6.Services;
using Microsoft.AspNetCore.Mvc;

namespace GrupaDotNet.Spotkanie6.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly CommentService _commentService;
        private readonly ICommentRepository _commentRepository;

        public CommentController(CommentService commentService, ICommentRepository commentRepository)
        {
            _commentService = commentService;
            _commentRepository = commentRepository;
        }

        [HttpGet]
        public IEnumerable<CommentDTO> Get(Guid authorId)
        {
            var comments = _commentRepository.GetByAuthor(authorId);
            return comments
                .Select(x => new CommentDTO(x.Id, $"{x.Author.FirstName} {x.Author.LastName}", x.Content));
        }

        [HttpPost]
        public void Add(AddCommentDTO command)
        {
            _commentService.Add(command.Id, command.AuthorId, command.Content);
        }
    }
}