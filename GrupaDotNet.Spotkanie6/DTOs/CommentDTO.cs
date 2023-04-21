using GrupaDotNet.Spotkanie6.Models;

namespace GrupaDotNet.Spotkanie6.DTOs
{
    public record CommentDTO(Guid Id, string AuthorFullName, string Content);
}
