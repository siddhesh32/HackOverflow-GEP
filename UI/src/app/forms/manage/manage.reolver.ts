import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve } from '@angular/router';
import { Observable } from 'rxjs';
import { ManageService } from './manage.service';

@Injectable()
export class ManageResolver implements Resolve<any> {
    constructor(public manageService: ManageService){}
        resolve(route: ActivatedRouteSnapshot): Observable<any> | Promise<any> | any {
            return this.manageService.getData();
        }
}
