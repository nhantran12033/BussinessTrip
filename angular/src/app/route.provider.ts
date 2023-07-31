import { RoutesService, eLayoutType } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const APP_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routesService: RoutesService) {
  return () => {
    routesService.add([
      {
        path: '/',
        name: '::Menu:Home',
        iconClass: 'fas fa-home',
        order: 1,
        layout: eLayoutType.application,
      },
      {
        path: '/businessTrip',
        name: 'Business Trip List',
        iconClass: 'fas fa-list',
        layout: eLayoutType.application,
      },
      {

        path: '/NewRequest',
        name: 'New Request',
        iconClass: 'fas fa-plus',
        layout: eLayoutType.application,
      },
      {
        path: '/trips',
        name: 'Business Trip',
        parentName: 'New Request',
        iconClass: 'fas fa-list',
        layout: eLayoutType.application,
      },
    ]);
  };
}
