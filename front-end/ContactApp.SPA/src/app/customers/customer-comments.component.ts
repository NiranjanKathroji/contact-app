import { Component, OnInit } from '@angular/core';
import { IEnquiry, ICustomer } from '../shared/interfaces';
import { ConfigService } from '../shared/utils/config.service';
import { CustomerService } from '../shared/services/customer.service';
import { NotificationService } from '../shared/utils/notification.service';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-customer-comments',
  templateUrl: './customer-comments.component.html',
  styleUrls: ['./customer-comments.component.css']
})
export class CustomerCommentsComponent implements OnInit {

  enquiries: IEnquiry[];
  customer: ICustomer;
  apiHost: string;
  userName: string;

  constructor(private configService: ConfigService,
    private customerService: CustomerService,
    private notificationService: NotificationService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.apiHost = this.configService.getApiHost();

    // Get customer current username from route.
    this.route.paramMap.subscribe(params => {
      this.userName = params.get('userName');
    });

    this.customerService.getCustomerByUserName(this.userName)
      .subscribe((customer: ICustomer) => {
        this.customer = customer;
        this.enquiries = customer.enquiries;
      },
      error => {
        this.notificationService.printErrorMessage('Failed to load customer. ' + error);
      });
  }

  // Track each items in passed to it to avoid reloading entire
  // DOM again and again.
  trackByEnquiryKey(index: number, enquiry: IEnquiry): number {
    return enquiry.id;
  }
}
