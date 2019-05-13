using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace IGI_3.Models
{
    public class Client
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string FirmName { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
