import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { ConfigurationService } from './configuration.service';
@Injectable()
export class ConfigurationResolver implements Resolve<any> {
    constructor(public configurationService: ConfigurationService){}
    resolve(route: ActivatedRouteSnapshot): Observable<any> | Promise<any> | any {
        return this.configurationService.getFieldName();
    }
}