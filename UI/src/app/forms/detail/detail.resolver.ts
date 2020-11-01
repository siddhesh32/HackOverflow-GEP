import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { DetailService } from './detail.service';
@Injectable()
export class DetailResolver implements Resolve<any> {
    constructor(public detailService: DetailService){}
    resolve(route: ActivatedRouteSnapshot): Observable<any> | Promise<any> | any {
        var id:string = "";
        if(localStorage.getItem('docid')){
            id = localStorage.getItem('docid');
        }
        else{
          id="";
        }
        debugger;
        return this.detailService.getConfigData(id);

    }
}
