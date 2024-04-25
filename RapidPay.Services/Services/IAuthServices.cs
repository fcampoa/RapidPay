using RapidPay.Domain.Models;

namespace RapidPay.Services.Services 
{
    public interface IAuthService
    {
        Task<(int, string)> Registeration(RegistrationModel model, string role);
        Task<(int, string)> Login(LoginModel model);
    }
}