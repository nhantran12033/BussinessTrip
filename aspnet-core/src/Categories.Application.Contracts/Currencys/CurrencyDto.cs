using System;
using System.Collections.Generic;
using System.Text;

namespace Categories.Currencys
{
    public class CurrencyDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public float ExchangeRate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
