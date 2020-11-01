import { Injectable, OnDestroy } from "@angular/core";
import { Observable, of } from 'rxjs';
import { ConfigService } from '../shared/configService.service';
import { BaseService } from '../shared/base.service';
@Injectable()
export class DetailService implements OnDestroy {
    constructor(public configService: ConfigService,public baseservice: BaseService) { }
    getConfigData(id: string): Observable<any> {
        if(id == "") {
         return this.getDefault()
        }
         else {
            return this.getDataOfId(id)
        }
    }
    getDefault(){
        return of({
            config: {
              documentType: {
                  name: 'Document Type',
                  isItext: false,
                  iText: ''
              },
              documentName: {
                  name: 'Document Name',
                  isItext: false,
                  iText: ''
              },
              itemName: {
                  name: 'Item Name',
                  isItext: false,
                  iText: ''
              },
              category: {
                  name: 'Category',
                  isItext: false,
                  iText: ''
              },
              businessUnit: {
                  name: 'Business Unit',
                  isItext: false,
                  iText: ''
              },
              region: {
                  name: 'Region',
                  isItext: false,
                  iText: ''
              }
          },
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
    getDataOfId(id:string){
        debugger;
        return this.baseservice.getData("http://localhost:59010/api/GetDocument?Id="+id,{});
    }
    saveData(data){
      debugger;
         this.baseservice.postData("http://localhost:59010/api/SaveDocument",data,{}).subscribe();
        //this.configService.setManageData({config:this.configService.getConfig(), data: data});
    }
    ngOnDestroy() { }
}
