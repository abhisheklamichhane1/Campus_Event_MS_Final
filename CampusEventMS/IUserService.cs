using System.Threading.Tasks;
using CampusEventMS.ViewModels;
using CampusEventMS.Data.Models;
using Microsoft.AspNetCore.Identity;

public interface IUserService
{
    Task<IdentityResult> RegisterUserAsync(RegisterViewModel model);
    Task<IdentityResult> ConfirmEmailAsync(string email, string token);
    Task<SignInResult> SignInAsync(LoginViewModel model);
    Task SignOutAsync();
    Task<ApplicationUser> FindUserByEmailAsync(string email);
    Task<string> GenerateJwtTokenAsync(ApplicationUser user);
}
