import { Injectable, OnDestroy } from '@angular/core';
import { of } from 'rxjs';
import { ConfigService } from '../shared/configService.service';

@Injectable()
export class ManageService implements OnDestroy {
    constructor(public configService: ConfigService){}
    getData(){
        debugger
        return of(this.configService.getManageData());
        // return of(
        //     [
        //         {
        //             'Document Name': 'Doc-123',
        //             'Document Type': 'Product',
        //             'Category': 'Chemicals',
        //             'Region': 'Malaysia',
        //             'Business Unit': 'SAP-123'
        //         },
        //         {
        //             'Document Name_1': 'Doc-123',
        //             'Document Type_1': 'Product',
        //             'Category_1': 'Chemicals',
        //             'Region': 'Malaysia',
        //             'Business Unit': 'SAP-123'
        //         },
        //         {
        //             'Document Name_2': 'Doc-123',
        //             'Document Type_2': 'Product',
        //             'Category_2': 'Chemicals',
        //             'Region': 'Malaysia',
        //             'Business Unit': 'SAP-123'
        //         },
        //         {
        //             'Document Name_3': 'Doc-123',
        //             'Document Type_3': 'Product',
        //             'Category_3': 'Chemicals',
        //             'Region': 'Malaysia',
        //             'Business Unit': 'SAP-123'
        //         }
        //     ]
        // )
    }
    ngOnDestroy(){}
}