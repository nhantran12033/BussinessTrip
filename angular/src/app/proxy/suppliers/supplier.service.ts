import type { SupplierDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class SupplierService {
  apiName = 'Default';
  

  createList = (supplierDto: SupplierDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, SupplierDto>({
      method: 'POST',
      url: '/api/app/supplier/list',
      body: supplierDto,
    },
    { apiName: this.apiName,...config });
  

  deleteList = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/supplier/${id}/list`,
    },
    { apiName: this.apiName,...config });
  

  getIDList = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, SupplierDto[]>({
      method: 'GET',
      url: `/api/app/supplier/${id}/i-dList`,
    },
    { apiName: this.apiName,...config });
  

  getList = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, SupplierDto[]>({
      method: 'GET',
      url: '/api/app/supplier',
    },
    { apiName: this.apiName,...config });
  

  getListWhere = (code: string, description: string, vendorName: string, vendorAccount: string, vendorHold: string, beneficiaryAccount: string, beneficiaryBankName: string, beneficiaryName: string, phone: string, email: string, taxCode: string, importBy: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, SupplierDto[]>({
      method: 'GET',
      url: '/api/app/supplier/where',
      params: { code, description, vendorName, vendorAccount, vendorHold, beneficiaryAccount, beneficiaryBankName, beneficiaryName, phone, email, taxCode, importBy },
    },
    { apiName: this.apiName,...config });
  

  updateList = (id: string, supplierDto: SupplierDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, SupplierDto>({
      method: 'PUT',
      url: `/api/app/supplier/${id}/list`,
      body: supplierDto,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
