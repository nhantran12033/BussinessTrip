using System;
using System.Collections.Generic;
using System.Text;

namespace Categories.TripExpenses
{
    public class TripExpenseDto
    { 
        public Guid Id { get; set; }

        public string Purpose { get; set; }
        public string Destination { get; set; }
        public DateTime CheckinTime { get; set; }
        public DateTime CheckoutTime { get; set; }
        public int TotalNights { get; set; }
        public string Item { get; set; }
        public string Specification { get; set; }
        public string OriginalCurrency { get; set; }
        public float OriginalUnit { get; set; }
        public float Volume { get; set; }
        public float OriginalAmount { get; set; }
        public float EquivalentInVND { get; set; }
        public string Notes { get; set; }
        public Guid TripId { get; set; }
    }
}
