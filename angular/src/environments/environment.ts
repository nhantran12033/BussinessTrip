import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'Categories',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44344/',
    redirectUri: baseUrl,
    clientId: 'Categories_App',
    responseType: 'code',
    scope: 'offline_access Categories',
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44344',
      rootNamespace: 'Categories',
    },
  },
} as Environment;
