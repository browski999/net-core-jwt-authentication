using Microsoft.EntityFrameworkCore;
using SecureWebApiJWT.Entities;
using SecureWebApiJWT.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecureWebApiJWT.Services
{
    public class OrderService : IOrderService
    {
        private readonly CustomerDbContext _customerDbContext;

        public OrderService(CustomerDbContext customerDbContext)
        {
            _customerDbContext = customerDbContext;
        }

        public async Task<List<Order>> GetOrdersByCustomerId(int id)
        {
            var orders = await _customerDbContext.Orders.Where(c => c.CustomerId == id).ToListAsync();

            return orders;
        }
    }
}
