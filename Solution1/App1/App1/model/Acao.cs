using System;
using System.Collections.Generic;
using System.Text;

namespace App1.model
{
    public class Acao
    {
        public int Id { get; set; }
        public String StockFund { get; set; }

        public String Amount { get; set; }

        public String Price { get; set; }

        public DateTime Date { get; set; }
    }
}
