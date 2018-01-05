import { Injectable } from '@angular/core';
// import { Predicate } from '../interfaces';
// import {alertify} from 'alertify.js';
const alertify: any = require('alertify.js');
const alertifyLogposition = 'top center';

// declare var alertify: any;

@Injectable()
export class NotificationService {
    private _notifier: any = null;

    constructor() {
        this._notifier = alertify;
        this._notifier.logPosition(alertifyLogposition);
    }

    /*
    Opens a confirmation dialog using the alertify.js lib
    */
    openConfirmationDialog(message: string, okCallback: () => any) {
        this._notifier.confirm(message, function (e: any) {
            if (e) {
                okCallback();
            } else {
            }
        });
    }

    /*
    Prints a success message using the alertify.js lib
    */
    printSuccessMessage(message: string) {
        this._notifier.success(message);
    }

    /*
    Prints an error message using the alertify.js lib
    */
    printErrorMessage(message: string) {
        this._notifier.error(message);
    }
}
