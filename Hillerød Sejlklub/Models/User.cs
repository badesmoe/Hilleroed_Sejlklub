namespace Hillerød_Sejlklub.Models
{

    public enum RoleType
    {
        Member,
        Admin
    }
    public class User
    {
        private static int _nextId = 1;

        #region Properties
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public RoleType Role { get; private set; }
        #endregion

        #region Constructor
        public User(string name, string email, int phone, RoleType role = RoleType.Member)
        {
            Name = name;
            Email = email;
            Phone = phone;
            Role = role;
            Id = _nextId++;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return
                $"Member ID: {Id}\n" +
                $"Name: {Name}\n" +
                $"Email: {Email}\n" +
                $"Phone: {Phone}\n" +
                $"Role: {Role}\n";
        }

        public void ChangeRoleTo(RoleType role)
        {
            Role = role;
        }
        #endregion


    }
}
