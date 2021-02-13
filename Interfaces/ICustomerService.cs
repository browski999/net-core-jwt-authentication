using SecureWebApiJWT.Requests;
using SecureWebApiJWT.Responses;
using System.Threading.Tasks;

namespace SecureWebApiJWT.Interfaces
{
    public interface ICustomerService
    {
        Task<LoginResponse> Login(LoginRequest loginRequest);
    }
}
