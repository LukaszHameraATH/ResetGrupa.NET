namespace GrupaDotNet.Shared
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User? GetById(Guid id);
        void Save(User user);
    }
}
