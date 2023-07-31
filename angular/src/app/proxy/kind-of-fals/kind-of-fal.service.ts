import { RestService, Rest } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { KindOfFALDto } from '../kind-of-fal/models';

@Injectable({
  providedIn: 'root',
})
export class KindOfFALService {
  apiName = 'Default';
  

  createList = (kindOfFALDto: KindOfFALDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, KindOfFALDto>({
      method: 'POST',
      url: '/api/app/kind-of-fAL/list',
      body: kindOfFALDto,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/kind-of-fAL/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, KindOfFALDto[]>({
      method: 'GET',
      url: '/api/app/kind-of-fAL',
    },
    { apiName: this.apiName,...config });
  

  getListIDById = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, KindOfFALDto[]>({
      method: 'GET',
      url: `/api/app/kind-of-fAL/${id}/i-d`,
    },
    { apiName: this.apiName,...config });
  

  getListWhereByKindAndDesAndModifiedby = (kind: string, des: string, modifiedby: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, KindOfFALDto[]>({
      method: 'GET',
      url: '/api/app/kind-of-fAL/where',
      params: { kind, des, modifiedby },
    },
    { apiName: this.apiName,...config });
  

  updateList = (id: string, kindOfFALDto: KindOfFALDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, KindOfFALDto>({
      method: 'PUT',
      url: `/api/app/kind-of-fAL/${id}/list`,
      body: kindOfFALDto,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
