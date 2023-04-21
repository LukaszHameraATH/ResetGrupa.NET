using GrupaDotNet.Spotkanie6.Models;

namespace GrupaDotNet.Spotkanie6.Infrastructure.Database
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> GetByAuthor(Guid authorId);
        void Add(Comment comment);
        bool IsExists(Guid id);
    }

    public class CommentRepository: ICommentRepository
    {
        private readonly List<Comment> _comments = new List<Comment>();
        public IEnumerable<Comment> GetByAuthor(Guid authorId)
        {
            return _comments
                .Where(x => x.Author.Id == authorId);
        }

        public void Add(Comment comment)
        {
            _comments.Add(comment); 
        }

        public bool IsExists(Guid id)
        {
            return _comments
                .Any(x => x.Id == id);
        }
    }
}
