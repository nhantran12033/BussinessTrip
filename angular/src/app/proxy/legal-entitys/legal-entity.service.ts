import type { LegalEntityDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class LegalEntityService {
  apiName = 'Default';
  

  createListLegal = (legalEntityDto: LegalEntityDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, LegalEntityDto>({
      method: 'POST',
      url: '/api/app/legal-entity/list-legal',
      body: legalEntityDto,
    },
    { apiName: this.apiName,...config });
  

  deleteLegal = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/legal-entity/${id}/legal`,
    },
    { apiName: this.apiName,...config });
  

  getListIDById = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, LegalEntityDto[]>({
      method: 'GET',
      url: `/api/app/legal-entity/${id}/i-d`,
    },
    { apiName: this.apiName,...config });
  

  getListLegal = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, LegalEntityDto[]>({
      method: 'GET',
      url: '/api/app/legal-entity/legal',
    },
    { apiName: this.apiName,...config });
  

  getListWhereListByCodeAndDescriptionAndImportBy = (code: string, description: string, importBy: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, LegalEntityDto[]>({
      method: 'GET',
      url: '/api/app/legal-entity/where-list',
      params: { code, description, importBy },
    },
    { apiName: this.apiName,...config });
  

  updateListLegal = (id: string, legalEntityDto: LegalEntityDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, LegalEntityDto>({
      method: 'PUT',
      url: `/api/app/legal-entity/${id}/list-legal`,
      body: legalEntityDto,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
