using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyProject.Models
{
    public class Method
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public List<Money> Moneys { get; set; }
    }
}