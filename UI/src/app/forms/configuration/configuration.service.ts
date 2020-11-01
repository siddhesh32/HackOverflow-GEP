import { Injectable, OnDestroy } from '@angular/core';
import { of } from 'rxjs';
import { ConfigService } from '../shared/configService.service';

@Injectable()
export class ConfigurationService implements OnDestroy {
    constructor(public configService: ConfigService){}
    getFieldName() {
        return of({
            documentType: {
                name: 'Document Type',
                isItext: true,
                iText: 'This is Document Name'
            },
            documentName: {
                name: 'Document Name',
                isItext: true,
                iText: 'This is Document Name'
            },
            itemName: {
                name: 'Item Name',
                isItext: true,
                iText: 'This is Document Name'
            },
            category: {
                name: 'Category',
                isItext: true,
                iText: 'This is Document Name'
            },
            businessUnit: {
                name: 'Business Unit',
                isItext: true,
                iText: 'This is Document Name'
            },
            region: {
                name: 'Region',
                isItext: false,
                iText: 'This is Document Name'
            }
        })
    };
    saveConfig(config){
        this.configService.saveConfig(config);
    }
    ngOnDestroy() { }
}