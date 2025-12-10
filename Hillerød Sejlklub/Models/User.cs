using Hillerød_Sejlklub.Repository;
using System.ComponentModel.DataAnnotations;

namespace Hillerød_Sejlklub.Models
{

    public enum RoleType
    {
        Member,
        Admin
    }
    public enum MemberType
    {
        Junior,
        Senior,
        Familie
    }
    public class User
    {
        private static int _nextId = 1;

        #region Properties
        public int Id { get; set; }
        [Display(Name = "Navn")]
        [Required(ErrorMessage = "Medlem skal have et navn")]
        public string? Name { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Medlem skal have en email")]
        public string? Email { get; set; }
        [Display(Name = "Tlf. Nummer")]
        [Required(ErrorMessage = "Medlem skal have et telefon nummer")]
        public int? Phone { get; set; }
        public RoleType Role { get; private set; }
        public MemberType MemberType { get; set; }
        #endregion

        #region Constructor

        public User () 
        {
            Id = _nextId++;
        }

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
