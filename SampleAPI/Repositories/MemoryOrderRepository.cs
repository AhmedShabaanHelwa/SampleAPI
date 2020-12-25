using SampleAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Repositories
{
    public class MemoryOrderRepository : IOrderRepository
    {
        //Private property
        private IList<Order> _orders { get; set; }
        //Constructor
        public MemoryOrderRepository()
        {
            _orders = new List<Order>();
        }

        public IEnumerable<Order> Get() =>_orders;
        
        public Order Get(Guid orderId) => _orders.FirstOrDefault(obj => obj.Id == orderId);
       
        public void Add(Order order) => _orders.Add(order);
        
        public void Update(Guid orderId, Order order)
        {
            //Get old item
            var result = _orders.FirstOrDefault(obj => obj.Id == orderId);
            if (result != null)
                result.ItemsIds = order.ItemsIds;
        }
        public Order Delete(Guid orderId)
        {
            var target = _orders.FirstOrDefault(order => order.Id == orderId);
            _orders.Remove(target);

            return target;
        }


    }
}
