import type { TripExpenseDto } from '../trip-expenses/models';

export interface TripInformationDto {
  id?: string;
  operaterName?: string;
  requestNumber?: string;
  requestedDate?: string;
  businessType?: string;
  legalEntity?: string;
  department?: string;
  expenseCode?: string;
  verifierUsername?: string;
  verifierName?: string;
  notes?: string;
  totalAmount: number;
  tripExpenseDetail: TripExpenseDto[];
}
