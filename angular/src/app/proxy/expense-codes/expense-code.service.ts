import type { ExpenseCodeDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ExpenseCodeService {
  apiName = 'Default';
  

  createList = (expenseCodeDto: ExpenseCodeDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ExpenseCodeDto>({
      method: 'POST',
      url: '/api/app/expense-code/list',
      body: expenseCodeDto,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/expense-code/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, ExpenseCodeDto[]>({
      method: 'GET',
      url: '/api/app/expense-code',
    },
    { apiName: this.apiName,...config });
  

  getListIDById = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ExpenseCodeDto[]>({
      method: 'GET',
      url: `/api/app/expense-code/${id}/i-d`,
    },
    { apiName: this.apiName,...config });
  

  getWhereListByCodeAndDesAndImportBy = (code: string, des: string, importBy: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ExpenseCodeDto[]>({
      method: 'GET',
      url: '/api/app/expense-code/where-list',
      params: { code, des, importBy },
    },
    { apiName: this.apiName,...config });
  

  updateList = (id: string, expenseCodeDto: ExpenseCodeDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ExpenseCodeDto>({
      method: 'PUT',
      url: `/api/app/expense-code/${id}/list`,
      body: expenseCodeDto,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
