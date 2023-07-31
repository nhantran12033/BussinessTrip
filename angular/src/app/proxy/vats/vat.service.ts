import type { VATDTO } from './models';
import { RestService, Rest } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class VATService {
  apiName = 'Default';
  

  createList = (VatDto: VATDTO, config?: Partial<Rest.Config>) =>
    this.restService.request<any, VATDTO>({
      method: 'POST',
      url: '/api/app/v-aT/list',
      body: VatDto,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/v-aT/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, VATDTO[]>({
      method: 'GET',
      url: '/api/app/v-aT',
    },
    { apiName: this.apiName,...config });
  

  getListIDById = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, VATDTO[]>({
      method: 'GET',
      url: `/api/app/v-aT/${id}/i-d`,
    },
    { apiName: this.apiName,...config });
  

  getListWhereInt = (vats: number, vataxcode: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, VATDTO[]>({
      method: 'GET',
      url: '/api/app/v-aT/where-int',
      params: { vats, vataxcode },
    },
    { apiName: this.apiName,...config });
  

  getListWhereString = (description: string, modifiedBy: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, VATDTO[]>({
      method: 'GET',
      url: '/api/app/v-aT/where-string',
      params: { description, modifiedBy },
    },
    { apiName: this.apiName,...config });
  

  updateList = (id: string, VatDto: VATDTO, config?: Partial<Rest.Config>) =>
    this.restService.request<any, VATDTO>({
      method: 'PUT',
      url: `/api/app/v-aT/${id}/list`,
      body: VatDto,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
