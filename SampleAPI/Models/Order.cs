using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Models
{
    public class Order
    {
        public Guid Id { set; get; }
        public string ItemsIds { set; get; }
    }
}
