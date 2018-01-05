// Import modules.
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { AngularFontAwesomeModule } from 'angular-font-awesome';


// Import components.
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { ContactUsComponent } from './contact-us/contact-us.component';
import { CustomerListComponent } from './customers/customer-list.component';
import { CustomerCommentsComponent } from './customers/customer-comments.component';

// Import services.
import { CustomerService } from './shared/services/customer.service';
import { EnquiryService } from './shared/services/enquiry.service';
import { ConfigService } from './shared/utils/config.service';
import { ItemService } from './shared/utils/item.service';
import { NotificationService } from './shared/utils/notification.service';
import { ErrorHandlingService } from './shared/utils/error-handling.service';


// Route configurations.
export const appRoutes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'customers', component: CustomerListComponent },
  { path: 'customers/:userName', component: CustomerCommentsComponent },
  { path: 'contact-us', component: ContactUsComponent },
  { path: '', redirectTo: '/customers', pathMatch: 'full' }
];


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ContactUsComponent,
    CustomerListComponent,
    CustomerCommentsComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRoutes),
    HttpModule,
    FormsModule,
    ReactiveFormsModule,
    AngularFontAwesomeModule
  ],
  providers: [
    ConfigService,
    CustomerService,
    EnquiryService,
    ItemService,
    NotificationService,
    ErrorHandlingService
  ],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule { }
