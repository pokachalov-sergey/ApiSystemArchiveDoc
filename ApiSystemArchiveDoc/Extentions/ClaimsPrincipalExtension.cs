using System.Security.Claims;

namespace ApiSystemArchiveDoc.Extentions;

public static class ClaimsPrincipalExtension
{
    public static string GetFirstName(this ClaimsPrincipal principal)
    {
  
        var firstName = principal.Claims.FirstOrDefault(c => c.Type == "FirstName");
        return firstName?.Value;
    }

    public static string GetLastName(this ClaimsPrincipal principal)
    {
        var lastName = principal.Claims.FirstOrDefault(c => c.Type == "LastName");
        return lastName?.Value;
    }
}