using SecureWebApiJWT.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecureWebApiJWT.Interfaces
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrdersByCustomerId(int id);
    }
}
