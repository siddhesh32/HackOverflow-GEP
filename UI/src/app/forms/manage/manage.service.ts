import { Injectable, OnDestroy } from '@angular/core';
import { of } from 'rxjs';
import { ConfigService } from '../shared/configService.service';

@Injectable()
export class ManageService implements OnDestroy {
    constructor(public configService: ConfigService){}
    getData(){
        return this.configService.getManageData();

    }
    ngOnDestroy(){}
}
