import { Component, OnInit, AfterViewInit, OnDestroy } from '@angular/core';
import { RetailerDashboardService } from 'src/app/services/retailer/retailer-dashboard.service'
import { Router } from '@angular/router';
import { UserService } from '../../services/user.service';
import { EventType } from 'src/app/models/incentive.model';
import { ContentProviderService } from 'src/app/services/content-provider.service';
import { Location } from '@angular/common';
import { ContentProviderLtdInfo } from 'src/app/models/contentprovider.model';

@Component({
  selector: 'app-retailer-milestones',
  templateUrl: './retailer-milestones.component.html',
  styleUrls: ['./retailer-milestones.component.css']
})
export class RetailerMilestonesComponent implements OnInit, AfterViewInit, OnDestroy {
  totalMilestoneEarnings = 0
  milestonesCarouselArr: Array<any> = [];
  partnerCode = sessionStorage.getItem('partnerCode');
  retailerPartnerProvidedId = sessionStorage.getItem('partnerProvidedId');
  baseHref = this.retailerDashboardService.getBaseHref();
  contentProviders: ContentProviderLtdInfo[];
  constructor(
    private retailerDashboardService: RetailerDashboardService,
    public router: Router,
    public location: Location,
    public userService: UserService,
    private contentProviderService: ContentProviderService
  ) { }

  ngOnInit(): void {
    this.getContentProviders();
    this.partnerCode = this.retailerDashboardService.getpartnerCode();
    this.retailerPartnerProvidedId = this.retailerDashboardService.getRetailerPartnerProvidedId();
    this.getMilestoneTotal();
  }


  getContentProviders() {
    if(sessionStorage.getItem("CONTENT_PROVIDERS")) {
      this.contentProviders =  JSON.parse(sessionStorage.getItem("CONTENT_PROVIDERS"));
      this.contentProviders.forEach(contentProvider => {
        this.contentProviders[contentProvider.contentProviderId] = contentProvider.name;
      }); 
    } else {
      this.contentProviderService.browseContentProviders().subscribe(res => {
        this.contentProviders = res;
        sessionStorage.setItem("CONTENT_PROVIDERS",  JSON.stringify(this.contentProviders));
        this.contentProviders.forEach(contentProvider => {
          this.contentProviders[contentProvider.contentProviderId] = contentProvider.name;
        }); 
      });
    }
  }


 

  getMilestoneTotal() {
    let totalMilestoneEarnings = 0;
    let milestonesCarouselArr = []
    this.retailerDashboardService.getMileStonesHome(this.partnerCode, this.retailerPartnerProvidedId).subscribe( res => {
      
      if(res.planDetails) {
        res.planDetails.forEach(planDetail => {
          if(planDetail.formula && planDetail.formula.formulaType === 'DIVIDE_AND_MULTIPLY') {
            planDetail.formulaName = planDetail.formula.formulaType;
            if(planDetail.result && planDetail.result.value) {
              const value = planDetail.result.value;
              totalMilestoneEarnings+=value;
            }
            if(!planDetail.result) {
              planDetail.result = {
                residualValue: 0,
                value: 0
              }
            }
            if(planDetail.formula.firstOperand && planDetail.formula.secondOperand && planDetail.result) {
              milestonesCarouselArr.push({
                formulaType: planDetail.formulaName,
                ruleType: planDetail.ruleType,
                firstOperand: planDetail.formula.firstOperand,
                secondOperand: planDetail.formula.secondOperand,
                value : planDetail.result.value ? planDetail.result.value : 0,
                residualValue : planDetail.result.residualValue ? planDetail.result.residualValue : 0,
                progress: ((planDetail.result.residualValue ? planDetail.result.residualValue : 0))*100/planDetail.formula.firstOperand,
                referral: planDetail.eventType === EventType['Retailer Referral'],
                contentProviderId: planDetail.eventSubType
              });
            } 
          } else if(planDetail.formula && planDetail.formula.formulaType === 'RANGE') {
            planDetail.formulaName = planDetail.formula.formulaType;
            if(planDetail.result && planDetail.result.value) {
              const value = planDetail.result.value;
              totalMilestoneEarnings+=value;      
            }
            if(!planDetail.result) {
              planDetail.result = {
                residualValue: 0,
                value: 0
              }
            }
            if(planDetail.result) {
              milestonesCarouselArr.push({
                formulaType: planDetail.formulaName,
                ruleType: planDetail.ruleType,
                value : planDetail.result.value ? planDetail.result.value : 0,
                eventType: planDetail.eventType,
                contentProviderId: planDetail.eventSubType
              });
            }
          }
        });
        this.totalMilestoneEarnings = totalMilestoneEarnings;
        this.milestonesCarouselArr = milestonesCarouselArr;
        // console.log(this.milestonesCarouselArr);
      }
    } ,err => {
      console.log('error in milestone fetch');
      this.totalMilestoneEarnings = totalMilestoneEarnings;
    });
  }

  getRegularRatesIncentives() {
    this.retailerDashboardService.getRegularRatesIncentives(this.partnerCode, this.retailerPartnerProvidedId).subscribe(
      res => {

      },
      err => {
        
      }
    )
  }

  
  navigateToDashboard() {
    this.location.back();
  }

  ngAfterViewInit() {
    console.log('setting routed to' + true);
    //this.userService.setRetailerRouted(true);
  }

  ngOnDestroy() {
    //this.userService.setRetailerRouted(false);
  }


}
