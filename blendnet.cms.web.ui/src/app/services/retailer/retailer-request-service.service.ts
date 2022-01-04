import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { CreatedOrder } from 'src/app/models/created-order.model';
import { environment } from 'src/environments/environment';
import { LogService } from '../log.service';

@Injectable({
  providedIn: 'root'
})
export class RetailerRequestService {

  baseUrl:string = environment.baseUrl+environment.omsApiUrl;
  incentiveBrowseUrl: string = environment.baseUrl+environment.incentiveBrowseApiUrl;
  retailerUrl = environment.baseUrl +  environment.retailerApiUrl;

  constructor(
    private logger: LogService,
    private http: HttpClient
  ) { }

  

  getOrders(phoneNumber: string, orderStatus:string[]): Observable<any> {
    let url = `${this.baseUrl}/Order/${phoneNumber}/orderlist`;
    let payload = {
      orderStatuses: orderStatus
    }

    this.logger.log('Fetching created orders');
    return this.http.post(url, payload).pipe(
      map((response: any) => {
        console.log("response: ", response);
        return response.map(order => {
          const subs = order.orderItems[0].subscription;
          console.log('subs: ', subs);
          const createdDate = new Date(order.orderCreatedDate);
          const now = new Date();
          const diffTime = Math.abs(now.getTime() - createdDate.getTime());
          const diffDays = Math.ceil(diffTime / (1000*60*60*24));
          return new CreatedOrder(order.id, subs.title, subs.price, diffDays);
        })
      })
    )
  }

  completeOrder(payload): Observable<any> {
    let url = `${this.baseUrl}/Order/completeorder`;
    this.logger.log('Completing order');
    return this.http.put(url, payload);
  }

  getIncentivePlan(partnerCode: string, retailerPartnerProvidedId: string): Observable<any> {
    let url = `${this.incentiveBrowseUrl}/retailer/active/${retailerPartnerProvidedId}/REGULAR/${partnerCode}`;
    this.logger.log('Getting incentive plan for order complete');
    return this.http.get(url);
  }

  getConfig(partnerCode: string): Observable<any> {
    let url = `${this.retailerUrl}/RetailerProvider/byPartnerCode/${partnerCode}`;
    this.logger.log('Getting config file');
    return this.http.get(url);
  }

}