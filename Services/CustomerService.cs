using SecureWebApiJWT.Entities;
using SecureWebApiJWT.Helpers;
using SecureWebApiJWT.Interfaces;
using SecureWebApiJWT.Requests;
using SecureWebApiJWT.Responses;
using System.Linq;
using System.Threading.Tasks;

namespace SecureWebApiJWT.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerDbContext _customersDbContext;

        public CustomerService(CustomerDbContext customerDbContext)
        {
            _customersDbContext = customerDbContext;
        }

        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            var customer = _customersDbContext.Customers.SingleOrDefault(c => c.Active
                && c.Username == loginRequest.Username);

            if (customer == null)
            {
                return null;
            }

            var passwordHash = HashingHelper.HashUsingPbkdf2(loginRequest.Password, customer.PasswordSalt);

            if (customer.Password != passwordHash)
            {
                return null;
            }

            var token = await Task.Run(() => TokenHelper.GenerateToken(customer));

            return new LoginResponse
            {
                Username = customer.Username,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Token = token
            };
        }
    }
}
