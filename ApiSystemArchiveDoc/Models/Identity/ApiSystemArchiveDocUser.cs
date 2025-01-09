
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity;

namespace ApiSystemArchiveDoc.Models.Identity;

// Add profile data for application users by adding properties to the ApiSystemArchiveDocUser class
public class ApiSystemArchiveDocUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Patronymic { get; set; }
    public string? Department { get; set; }
}
