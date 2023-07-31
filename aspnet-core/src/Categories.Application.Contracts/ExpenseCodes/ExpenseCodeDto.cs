using System;
using System.Collections.Generic;
using System.Text;

namespace Categories.ExpenseCodes
{
    public class ExpenseCodeDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string ImportBy { get; set; }
    }
}
