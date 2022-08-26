using System;
using System.Threading.Tasks;
using EcommerceCore.Models;
using EcommerceCore.ViewModel;

namespace EcommerceCore.Interfaces
{
    public interface IAuth
    {
        Task<Users> Login(LoginViewModel model);
        Task<bool> Register(RegisterViewModel model);
    }
}
