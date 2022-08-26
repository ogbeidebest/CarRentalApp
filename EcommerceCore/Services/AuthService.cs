using System;
using System.Linq;
using System.Threading.Tasks;
using EcommerceCore.Interfaces;
using EcommerceCore.Models;
using EcommerceCore.ViewModel;

namespace EcommerceCore.Services
{
    public class AuthService : IAuth
    {
        private readonly IUtilities _utilities;
        private readonly IReadWriteToJson _readWriteToJson;
        public AuthService(IUtilities utilities, IReadWriteToJson readWriteToJson)
        {
            _readWriteToJson = readWriteToJson;
            _utilities = utilities;
        }
        public async Task<Users> Login(LoginViewModel model)
        {
            var hashPassword = _utilities.ComputeSha256Hash(model.Password);

            var users = await _readWriteToJson.ReadJson<Users>("Users.json");

            var result = users.Where(x => x.Password == hashPassword && x.EmailAddress == model.Email).SingleOrDefault();

            return result;
        }

        public async Task<bool> Register(RegisterViewModel model)
        {
            var hashPassword = _utilities.ComputeSha256Hash(model.Password);

            var user = new Users()
            {
                Id = Guid.NewGuid().ToString(),
                FullName = model.Fullname,
                EmailAddress = model.Email,
                Password = hashPassword,
                MobileNumber = model.Phone,
                IsActive = true,
                Created_at = DateTime.Now
            };

            var result = await _readWriteToJson.WriteJson<Users>(user, "Users.json");

            return result;
        }
    }
}
