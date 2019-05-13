using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace IGI_3.Models
{
    public class Furniture
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Material { get; set; }
        public string Description { get; set; }
        public int Cost { get; set; }
        public int Count { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
