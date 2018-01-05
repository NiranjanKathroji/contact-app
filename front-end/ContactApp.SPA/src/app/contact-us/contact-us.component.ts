import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, ReactiveFormsModule } from '@angular/forms';
import { Message } from '@angular/compiler/src/i18n/i18n_ast';
import { EnquiryService } from '../shared/services/enquiry.service';
import { NotificationService } from '../shared/utils/notification.service';
import { IEnquiry, ICustomer } from '../shared/interfaces';


@Component({
  selector: 'app-contact-us',
  templateUrl: './contact-us.component.html',
  styleUrls: ['./contact-us.component.css']
})
export class ContactUsComponent implements OnInit {
  contactForm: FormGroup;

  constructor(formBuilder: FormBuilder,
    private enquiryService: EnquiryService,
    private notificationService: NotificationService) {
    this.contactForm = formBuilder.group({

      // The first item in the array is the default value if any,
      // then the next item in the array is the validator.
      userName: [
        null, Validators.compose([Validators.required,
        Validators.minLength(8), Validators.maxLength(100)])
      ],
      firstName: [
        null, Validators.compose([Validators.required, Validators.minLength(2), Validators.maxLength(100)])
      ],
      lastName: null,
      email: [null, Validators.compose([Validators.required, Validators.email])],
      gender: [null, Validators.required],
      title: [
        null, Validators.compose([Validators.required, Validators.minLength(10), Validators.maxLength(200)])
      ],
      message: [
        null, Validators.compose([Validators.required, Validators.minLength(20), Validators.maxLength(2000)])
      ]
    });
  }


  createEnquiry(postedFormData: any) {

    if (this.contactForm.valid) {
      // Map posted data to Enquiry type.
      const enquiry = {
        customer: {
          userName: <string>postedFormData.userName,
          firstName: <string>postedFormData.firstName,
          lastName: <string>postedFormData.lastName,
          email: <string>postedFormData.email,
          gender: <string>postedFormData.gender,
          avatar: 'default.png'
        },
        title: <string>postedFormData.title,
        message: <string>postedFormData.message
      };

      // Post enquiry to server.
      this.enquiryService.createEnquiry(<IEnquiry>enquiry)
        .subscribe((enquiryCreated) => {
          // Reset the form data after successful submit.
          this.contactForm.reset();
          this.notificationService.printSuccessMessage('Your enquiry has been submitted.');
        },
        error => {
          this.notificationService.printErrorMessage('Failed to post enquiry');
          this.notificationService.printErrorMessage(error);
        });
    }

  }

  ngOnInit() {
  }
}
