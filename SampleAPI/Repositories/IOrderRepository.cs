using SampleAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Repositories
{
    public interface IOrderRepository
    {
        public IEnumerable<Order> Get();
        public Order Get(Guid id);
        public void Add(Order order);
        public void Update(Guid orderId, Order orderItem);
        public Order Delete(Guid orderId);
    }
}
