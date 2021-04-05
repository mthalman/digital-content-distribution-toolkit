import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot } from '@angular/router';
import { MsalService } from '@azure/msal-angular';
import { AccountInfo } from '@azure/msal-common';
import { roles } from '../b2c-config';

interface Account extends AccountInfo {
  idTokenClaims?: {
    groups?: string[]
  }
}

@Injectable({
    providedIn: 'root'
  })
export class RoleGuardService implements CanActivate {

  constructor(private authService: MsalService) {}
  
  canActivate(route: ActivatedRouteSnapshot): boolean {
    const expectedRole = route.data.expectedRole;
    let account: Account = this.authService.instance.getAllAccounts()[0];

    if (!account.idTokenClaims?.groups) {
      window.alert('Token does not have roles claim. Please ensure that your account is assigned to an app role and then sign-out and sign-in again.');
      return false;
    } else if (!account.idTokenClaims?.groups?.includes(expectedRole)) {
      window.alert('You do not have access as expected role is missing. Please ensure that your account is assigned to an app role and then sign-out and sign-in again.');
      return false;
    } else if(!localStorage.getItem("contentProviderId") 
      && !route.data.isContentProviderSelectPage
      && account.idTokenClaims?.groups?.includes(expectedRole)
      && expectedRole === roles.SuperUser) {
    window.alert("Please select a Content Provider to access the management services");
    return false;
  }

    return true;
  }
}