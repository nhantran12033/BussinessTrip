import type { CurrencyDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class CurrencyService {
  apiName = 'Default';
  

  createList = (currencyDto: CurrencyDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CurrencyDto>({
      method: 'POST',
      url: '/api/app/currency/list',
      body: currencyDto,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/currency/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, CurrencyDto[]>({
      method: 'GET',
      url: '/api/app/currency',
    },
    { apiName: this.apiName,...config });
  

  getListIDById = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CurrencyDto[]>({
      method: 'GET',
      url: `/api/app/currency/${id}/i-d`,
    },
    { apiName: this.apiName,...config });
  

  getListWhere = (code: string, title: string, ex: number, modified: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CurrencyDto[]>({
      method: 'GET',
      url: '/api/app/currency/where',
      params: { code, title, ex, modified },
    },
    { apiName: this.apiName,...config });
  

  updateList = (id: string, currencyDto: CurrencyDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CurrencyDto>({
      method: 'PUT',
      url: `/api/app/currency/${id}/list`,
      body: currencyDto,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
