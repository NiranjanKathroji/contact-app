import { Component, OnInit } from '@angular/core';
import { ICustomer } from '../shared/interfaces';
import { ConfigService } from '../shared/utils/config.service';
import { CustomerService } from '../shared/services/customer.service';
import { NotificationService } from '../shared/utils/notification.service';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.css']
})
export class CustomerListComponent implements OnInit {

  customers: ICustomer[];
  apiHost: string;

  constructor(private configService: ConfigService,
    private customerService: CustomerService,
    private notificationService: NotificationService) { }

  ngOnInit() {
    this.apiHost = this.configService.getApiHost();
    this.customerService.getCustomers()
      .subscribe((customers: ICustomer[]) => {
        this.customers = customers;
      },
      error => {
        this.notificationService.printErrorMessage('Failed to load users. ' + error);
      });
  }

  // Track each items in passed to it to avoid reloading entire
  // DOM again and again.
  trackByCustomerKey(index: number, customer: ICustomer): number {
    return customer.id;
  }

}
