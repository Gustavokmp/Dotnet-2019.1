using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Acoes.api.model
{
    public class Acao
    {
        public int Id { get; set; }
        public String StockFund { get; set; }

        public int Amount { get; set; }

        public Decimal Price { get; set; }

        public DateTime Date { get; set; }
    }
}
