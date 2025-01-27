using Minimal.Domain.Shared.EntityModel;
using Minimal.Domain.Shared.Enums;

namespace Minimal.Domain.Users;

public class User : EntityModel
{
    public string? Name { get; private set; }
    public UserStatus Status { get; private set; }
    public string? Email { get; private set; }
    public string? PhoneNumber { get; private set; }
    
    
    public void UpdateName(string name) => Name = name.Trim();
    public void UpdateEmail(string email) => Email = email.Trim();
    public void UpdatePhoneNumber(string phoneNumber) => PhoneNumber = phoneNumber.Trim();

    public static class Factory
    {
        public static User Create(string name, string email, string phoneNumber)
        {
            var entity = new User
            {
                Id = Guid.NewGuid(),
                Status = UserStatus.Active,
                CreatedAt = DateTimeOffset.UtcNow
            };

            entity.UpdateName(name);
            entity.UpdateEmail(email);
            entity.UpdatePhoneNumber(phoneNumber);
            
            return entity;
        }
    }
}

