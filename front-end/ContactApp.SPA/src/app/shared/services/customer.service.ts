import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';

// Grab everything with import 'rxjs/Rx';
import { Observable } from 'rxjs/Observable';
import { Observer } from 'rxjs/Observer';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

import { ICustomer } from '../interfaces';
import { ConfigService } from '../utils/config.service';
import { ErrorHandlingService } from '../utils/error-handling.service';

@Injectable()
export class CustomerService {

    _baseApiUrl: string = '';
    _controllerName = 'customers/';

    constructor(private http: Http,
      private configService: ConfigService,
      private errorHandlingService: ErrorHandlingService) {
        this._baseApiUrl = configService.getApiURI();
    }

    getCustomers(): Observable<ICustomer[]> {
        return this.http.get(this._baseApiUrl + this._controllerName)
            .map((res: Response) => {
                return res.json();
            })
            .catch(this.errorHandlingService.handleError);
    }

    getCustomer(id: number): Observable<ICustomer> {
        return this.http.get(this._baseApiUrl + this._controllerName + id)
            .map((res: Response) => {
                return res.json();
            })
            .catch(this.errorHandlingService.handleError);
    }

    getCustomerByUserName(userName: string): Observable<ICustomer> {
        return this.http.get(this._baseApiUrl + this._controllerName + userName)
            .map((res: Response) => {
                return res.json();
            })
            .catch(this.errorHandlingService.handleError);
    }

    createCustomer(customer: ICustomer): Observable<ICustomer> {

        const headers = new Headers();
        headers.append('Content-Type', 'application/json');

        return this.http.post(this._baseApiUrl + this._controllerName, JSON.stringify(customer), {
            headers: headers
        })
            .map((res: Response) => {
                return res.json();
            })
            .catch(this.errorHandlingService.handleError);
    }
}
