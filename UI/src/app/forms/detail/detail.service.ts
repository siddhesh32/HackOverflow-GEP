import { Injectable, OnDestroy } from "@angular/core";
import { Observable, of } from 'rxjs';
import { ConfigService } from '../shared/configService.service';
@Injectable()
export class DetailService implements OnDestroy {
    constructor(public configService: ConfigService) { }
    getConfigData(id: number): Observable<any> {
        if(id === 0) {
            return this.getDefault()
        } else {
            return this.getDataOfId(id)
        }
    }
    getDefault(){
        return of({
            config: this.configService.getConfig(),
            data: {
                documentType: 'Product',
                documentName: '',
                itemName: '',
                category: '',
                businessUnit: '',
                region: ''
            }
        })
    }
    getDataOfId(id){
        return of({
            config: this.configService.getConfig(),
            data: {
                documentType: 'Product',
                documentName: 'DOC-1234',
                itemName: 'Item 1',
                category: 'Chemicals',
                businessUnit: 'SAP-1234',
                region: 'Malaysia'
            }
        })
    }
    saveData(data){
        this.configService.setManageData({config:this.configService.getConfig(), data: data});
    }
    ngOnDestroy() { }
}