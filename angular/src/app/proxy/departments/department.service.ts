import type { DepartmentDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class DepartmentService {
  apiName = 'Default';
  

  createList = (departmentDto: DepartmentDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, DepartmentDto>({
      method: 'POST',
      url: '/api/app/department/list',
      body: departmentDto,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/department/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DepartmentDto[]>({
      method: 'GET',
      url: '/api/app/department',
    },
    { apiName: this.apiName,...config });
  

  getListIDById = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, DepartmentDto[]>({
      method: 'GET',
      url: `/api/app/department/${id}/i-d`,
    },
    { apiName: this.apiName,...config });
  

  getListWhereByCodeAndDesAndImportby = (code: string, des: string, importby: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, DepartmentDto[]>({
      method: 'GET',
      url: '/api/app/department/where',
      params: { code, des, importby },
    },
    { apiName: this.apiName,...config });
  

  updateList = (id: string, departmentDto: DepartmentDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, DepartmentDto>({
      method: 'PUT',
      url: `/api/app/department/${id}/list`,
      body: departmentDto,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
