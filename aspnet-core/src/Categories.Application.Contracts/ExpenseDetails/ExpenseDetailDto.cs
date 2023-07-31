using System;
using System.Collections.Generic;
using System.Text;

namespace Categories.ExpenseDetail
{
    public class ExpenseDetailDto
    {
        public Guid Id { get; set; }
        public string Item { get; set; }
        public string Specification { get; set; }
        public string OriginalCurrency { get; set; }
        public float OriginalUnit { get; set; }
        public float Volume { get; set; }
        public float OriginalAmount { get; set; }
        public float EquivalentInVND { get; set; }
        public string Notes { get; set; }
    }
}
