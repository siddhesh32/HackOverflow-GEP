import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import { catchError, tap } from 'rxjs/operators';
import { IRequestObject } from './IRequestObject';

@Injectable({providedIn :'root'})
export class BaseService {

  constructor(private httpClient: HttpClient) { }

  getRequestObject(url: string, method: string): IRequestObject {    let req: IRequestObject = <IRequestObject>{};
    req.method = method;
    req.url = url;
    req.headers = {
      "Content-Type": "application/json"
    };
    return req;
  };
  processRequestObject<T>(requestObject: IRequestObject): Observable<T> {
    let observable: Observable<T>;
    switch (requestObject.method.toLowerCase()) {
      case 'get':
        observable = this.getData(requestObject.url, requestObject.headers);
        break;
      case 'post':
        observable = this.postData(requestObject.url, requestObject.data, requestObject.headers);
        break;
    }
    return observable;

  };
  postData(url: string, data: any, headers: any): Observable<any> {
    const httpOptions = {
      headers: headers
    };
    /* istanbul ignore next */
    let data1;
    /* istanbul ignore next */
    return this.httpClient.post<any>(url, data, httpOptions).pipe(
			tap((response: any) => { data1= response }),
			catchError((err,caught)=>(this.errorHandler<any>(err, caught)))
		);
  }
  getData(url: string, headers: any): Observable<any> {
    const httpOptions = {
      headers: headers
    };
    /* istanbul ignore next */
    let data;
    /* istanbul ignore next */
    return this.httpClient.get(url, httpOptions).pipe(
			tap((response: any) => { data= response }),
			catchError((err,caught)=>(this.errorHandler<any>(err, caught)))
		);

  };
  /* istanbul ignore next */
  private errorHandler<T>(err,caught): Observable<T>
  {
    throw err;
  }
}
