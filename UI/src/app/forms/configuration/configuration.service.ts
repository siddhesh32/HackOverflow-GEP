import { Injectable, OnDestroy } from '@angular/core';
import { of } from 'rxjs';
import { BaseService } from '../shared/base.service';
import { ConfigService } from '../shared/configService.service';

@Injectable()
export class ConfigurationService implements OnDestroy {
    constructor(public configService: ConfigService){}
    getFieldName() {
        return this.configService.getConfig();
    };
    saveConfig(config){
        this.configService.saveConfig(config);
    }
    ngOnDestroy() { }
}
