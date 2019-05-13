using System;
using System.Collections.Generic;
using System.Text;

namespace IGI_3.Models
{
    public class Order
    {
        public int ID { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsOrderComplete { get; set; }
        public int Discount { get; set; }
        public int Count { get; set; }
        public Furniture Furniture { get; set; }
        public Client Client { get; set; }
        public Worker Worker { get; set; }
    }
}
