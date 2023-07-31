import type { TripInformationDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class TripInformationService {
  apiName = 'Default';
  

  createTripInformation = (dto: TripInformationDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, TripInformationDto>({
      method: 'POST',
      url: '/api/app/trip-information/trip-information',
      body: dto,
    },
    { apiName: this.apiName,...config });
  

  deleteList = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/trip-information/${id}/list`,
    },
    { apiName: this.apiName,...config });
  

  getListID = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, TripInformationDto>({
      method: 'GET',
      url: `/api/app/trip-information/${id}/i-d`,
    },
    { apiName: this.apiName,...config });
  

  getTripInformation = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, TripInformationDto[]>({
      method: 'GET',
      url: '/api/app/trip-information/trip-information',
    },
    { apiName: this.apiName,...config });
  

  updateList = (id: string, dto: TripInformationDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, TripInformationDto>({
      method: 'PUT',
      url: `/api/app/trip-information/${id}/list`,
      body: dto,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
