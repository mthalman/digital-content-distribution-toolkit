import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { LogService } from './log.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl = environment.userApiUrl;

  constructor(
    private logger: LogService,
    private http: HttpClient
  ) { }

  getUserDetails(upn){
    let url = this.baseUrl + '/getuser?upn=' + 'upn';
    this.logger.log(`Fetching user details`);
    return this.http.get(url);
  }
}