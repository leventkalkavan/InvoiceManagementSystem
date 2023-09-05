using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Authentication;

public class AppRole: IdentityRole
{

    public DateTime CreatedDate { get; set; }
}