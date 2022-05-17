using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab3.Models;


public class User:IdentityUser
{
	// public int UserId { get; set; }
    [PersonalData]
    public string? Name { get; set; }
    // public string? Email { get; set; }
    [PersonalData]
    public int StreetNumber { get; set; } = 1;
    [PersonalData]
    public string? StreetName { get; set; }
    [PersonalData]
    [RegularExpression(@"^[A-Za-z][0-9][A-Za-z][ ]*[0-9][A-Za-z][0-9]$")]
    public string? PostalCode { get; set; }
    [PersonalData]
    public string? City { get; set; }
    [PersonalData]
    public string? Province { get; set; }
    [PersonalData]
    public string? Phone { get; set; }
    
    public bool isAdmin {get;set;} = false;
}