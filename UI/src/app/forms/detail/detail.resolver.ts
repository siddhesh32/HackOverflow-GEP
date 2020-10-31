import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { DetailService } from './detail.service';
@Injectable()
export class DetailResolver implements Resolve<any> {
    constructor(public detailService: DetailService){}
    resolve(route: ActivatedRouteSnapshot): Observable<any> | Promise<any> | any {
        let id = 0;
        if(localStorage.getItem('docid')){
            id = parseInt(localStorage.getItem('docid'))
        }
        return this.detailService.getConfigData(id);
    }
}