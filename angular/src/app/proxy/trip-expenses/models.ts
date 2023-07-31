
export interface TripExpenseDto {
  id?: string;
  purpose?: string;
  destination?: string;
  checkinTime?: string;
  checkoutTime?: string;
  totalNights: number;
  item?: string;
  specification?: string;
  originalCurrency?: string;
  originalUnit: number;
  volume: number;
  originalAmount: number;
  equivalentInVND: number;
  notes?: string;
  tripId?: string;
}
