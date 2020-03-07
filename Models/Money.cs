using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MoneyProject.Models
{
    public class Money
    {
        private DateTime _date = DateTime.Now;

        public int Id { get; set; }
        public string MaSV { get; set; }
        public int CountD { get; set; }
        public DateTime Date { get { return _date; } set { _date = value; } }
        [ForeignKey("Method")]
        public int MethodId { get; set; }
        public virtual Method Method { get; set; }
    }
}