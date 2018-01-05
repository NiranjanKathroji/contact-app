import { Injectable } from '@angular/core';

@Injectable()
// Class contains custom methods for manipulating mostly arrays.
export class ItemService {

  constructor() { }

  /*
    Util method to serialize a string to a specific Type
    */
    getSerialized<T>(arg: any): T {
      return <T>JSON.parse(JSON.stringify(arg));
  }
}
