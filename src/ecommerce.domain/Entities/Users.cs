using ecommerce.domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ecommerce.domain.Entities;
public class User
{
    public User(
        string fullname,
        string email,
        string username,
        string phonenumber,
        string password,
        string salt, 
        UserRoles role, 
        Guid addressId)
    {
        Fullname = fullname;
        Email = email;
        Username = username;
        Phonenumber = phonenumber;
        Password = password;
        Salt = salt;
        Role = role;
        Status = UserStatus.New;
        AddressId = addressId;
    }

    public Guid Id { get; private set; }

    [MaxLength(30)]
    public string Fullname { get; private set; }

    [MaxLength(100)]
    public string Email { get; private set; }

    [MaxLength(100)]
    public string Username { get; private set; }

    [MaxLength(30)]
    public string Phonenumber { get; private set; }

    [MaxLength(100)]
    public string Password { get; private set; }

    [MaxLength(255)]
    public string Salt { get; set; }

    public DateTime? LastLogin { get; private set; }
    public UserStatus Status { get; private set; }
    public UserRoles Role { get; private set; }
    public ICollection<OtpCode> OtpCodes { get; private set; }

    public Guid AddressId { get; set; }
    public Address? Address { get; set; }

    public void MarkAsActive() => Status = UserStatus.Active;
}
