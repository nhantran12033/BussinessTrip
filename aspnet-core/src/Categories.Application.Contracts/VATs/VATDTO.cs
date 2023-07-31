using System;
using System.Collections.Generic;
using System.Text;

namespace Categories.VATs
{
    public class VATDTO
    {
        public Guid Id { get; set; }
        public int VATs { get; set; }
        public int VATAxCode { get; set; }
        public string Description { get; set; }
        public DateTime Modified { get; set; }
        public string ModifiedBy { get; set; }
    }
}
