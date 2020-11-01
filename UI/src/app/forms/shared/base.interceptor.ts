import { Injectable } from "@angular/core";
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';

declare var userInfo: any;
@Injectable()
export class BaseInterceptService implements HttpInterceptor {

  constructor() {

  }
  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    request = request.clone({
      setHeaders: {
        "BPC":"123",
        "AppName":"Contract",
        "UseCase": "Contract"
      }
    });
    return next.handle(request);
  }
}
