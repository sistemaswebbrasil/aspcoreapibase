using System.ComponentModel.DataAnnotations;

/// <summary>
/// Data to be sent for authentication
/// </summary>
public class TokenRequest
{
    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

}
