using GrupaDotNet.Spotkanie6.Infrastructure.Database;
using GrupaDotNet.Spotkanie6.Models;

namespace GrupaDotNet.Spotkanie6.Services
{
    public class CommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IAuthorRepository _authorRepository;

        public CommentService(ICommentRepository commentRepository, IAuthorRepository authorRepository)
        {
            _commentRepository = commentRepository;
            _authorRepository = authorRepository;
        }

        public void Add(Guid id, Guid authorId, string content)
        {
            var author = _authorRepository.GetById(authorId);
            if (author is null)
                throw new Exception($"Author with id {authorId} not found.");

            if (_commentRepository.IsExists(id))
                throw new Exception($"Comment with id {id} already exists.");

            var comment = new Comment(id, author, content);
            _commentRepository.Add(comment);
        }
    }
}
