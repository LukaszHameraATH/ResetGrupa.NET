namespace GrupaDotNet.Shared
{
    public class User
    {
        public User(Guid id, string firstName, string lastName, bool isActive)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            IsActive = isActive;
        }

        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public bool IsActive { get; private set; }

        public void Deactivate()
        {
            IsActive = false;
        }
    }
}